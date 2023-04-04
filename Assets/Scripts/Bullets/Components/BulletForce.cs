using System;
using Common;
using UnityEngine;

namespace Bullets.Components
{
    public class BulletForce : BulletComponent<ForceData>
    {
        Rigidbody2D rb;
        private bool isReadyForForce = true;
        private void OnEnable() {
            isReadyForForce = true;
        }
        private void Update() {
            if(isReadyForForce)
            {
                SetVelocity();
                isReadyForForce = false;
            }
        }
        private void Start()
        {
            #region Add Force
            
            //Add Force to Bullet
            rb = _bullet.GetComponent<Rigidbody2D>();
            
            
            #endregion
            
        }
        
        public void SetVelocity()
        {   
            Vector2 forceDirection = new Vector2(Mathf.Cos(transform.eulerAngles.z * Mathf.Deg2Rad), 
                                                 Mathf.Sin(transform.eulerAngles.z * Mathf.Deg2Rad));
            rb.AddForce(forceDirection * _componentData._magnitude, ForceMode2D.Impulse);
        }
        
    }
}