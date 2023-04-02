using System;
using Bullets.Components.ComponentsData;
using Unity.VisualScripting;
using UnityEngine;

public class BulletDespawned : BulletComponent<BulletDespawnedData>
{
    private float disLimit;
    [SerializeField] protected float distance;
    [SerializeField] protected Transform mainCam;

    protected void FixedUpdate()
    {
            Despawning();
    }

    protected override void Awake()
    {
        base.Awake();
        LoadCamera();
    }

    protected void Start()
    {
        disLimit = _componentData.distance;
    }

    protected virtual void LoadCamera()
        {
            if (this.mainCam != null) return;
            this.mainCam = Transform.FindObjectOfType<Camera>().transform;
        }
    
        protected virtual void Despawning()
        {
            if (!this.CanDespawn()) return;
            this.DespawnObject();
        }
    
        protected virtual void DespawnObject()
        {
            BulletSpawner.Instance.Despawn(this.transform);
        }

        protected virtual bool CanDespawn()
        {
            this.distance = Vector3.Distance(transform.position, this.mainCam.position);
            if (this.distance > this.disLimit) return true;
            return false;
        }    
    }

