using System;
using Bullets.Components;
using UnityEngine;
[Serializable]
public class ForceData : ComponentData
{
    [field: SerializeField] public float _magnitude { get; private set; }
    [field: SerializeField] public Vector2 direction { get; protected set; }
    
    protected override void SetComponentDependency()
    {
        _componentDependency = typeof(BulletForce);
    }
}
