using System;
using Common;
using UnityEngine;

namespace Bullets.Components
{
    public class BulletForce : BulletComponent<ForceData>
    {
        private void Start()
        {
            #region Add Force

            //Add Force to Bullet
            Rigidbody2D rb = _bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(_bullet.firePoint.up * _componentData._magnitude, ForceMode2D.Impulse);

            #endregion
            
        }
        
    }
}