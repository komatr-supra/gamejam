using System;
using UnityEngine;


public class BulletSpawner : Spawner
{
    public static BulletSpawner Instance;

    
    
    

    public void Shoot(Vector3 firePoint, Quaternion quaternionRotation)
    {
        GameObject bullet = BulletSpawner.Instance.Spawn(firePoint, quaternionRotation).gameObject;
        
    }
    
    private void Awake() {
        if(Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        LoadComponents("BulletPrefab");
        
    }
    
}
