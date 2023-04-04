using System;
using UnityEngine;


public class BulletSpawner : Spawner
{
    public static BulletSpawner Instance;

    public Transform _firePoint
    {
        get => firePoint;
        private set
        {
            firePoint = value;
        }
    }
    
    [SerializeField] private Transform firePoint;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void LoadFirepoint()
    {
        this.firePoint = transform.Find("FirePoint");
    }

    void Shoot()
    {
        GameObject bullet = BulletSpawner.Instance.Spawn(firePoint.position, firePoint.rotation).gameObject;
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
        LoadFirepoint();
    }
    
}
