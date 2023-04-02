using System;
using Bullets.Components.ComponentsData;
using Common;
using UnityEngine;

namespace Bullets.Components
{
    public class BulletDamage : BulletComponent<DamageData>
    {
        private DamageDealer _damageDealer;

        private void Start()
        {
            _damageDealer = _bullet._DamageDealer.GetComponent<DamageDealer>();
            _damageDealer._damage = _componentData.damage;
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            _damageDealer.DealDame(col.transform);
        }
    }
}