using System;
using UnityEngine;

namespace Bullets.Components.ComponentsData
{
    [Serializable]
    public class WeaponSprite : ComponentData
    {
        [field: SerializeField] public Sprite _weaponSprite { get; private set; }
        
        protected override void SetComponentDependency()
        {
            _componentDependency = typeof(WeaponSprite);
        }
    }
}