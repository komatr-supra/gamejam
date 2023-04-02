using UnityEngine;


public abstract class BulletComponent : MonoBehaviour
{
    protected Bullet _bullet;
    public virtual void Init(){}

    protected virtual void Awake()
    {
        _bullet = GetComponent<Bullet>();
    }
}

public abstract class BulletComponent<T1> : BulletComponent where T1 : ComponentData
{
    protected T1 _componentData;
    
    public override void Init()
    {
        base.Init();
        _componentData = _bullet._data.GetData<T1>();
    }
}
