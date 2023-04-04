using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private Quaternion rotationQuaternion;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Shoot()
    {
        BulletSpawner.Instance.Shoot(transform.GetChild(0).position ,rotationQuaternion);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 dir = MouseCursor.Instance.WorldMousePosition - (Vector2)transform.position ;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotationQuaternion = Quaternion.Euler(0,0,angle);
        transform.localRotation = rotationQuaternion;
    }
}
