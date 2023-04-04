using System;
using UnityEngine;

namespace Bullets.Components.ComponentsData
{
    [Serializable]
    public class DamageData : ComponentData
    {
       [field: SerializeField] public int damage { get; private set; }
       
       protected override void SetComponentDependency()
       {
           _componentDependency = typeof(BulletDamage);
       }
    }
}