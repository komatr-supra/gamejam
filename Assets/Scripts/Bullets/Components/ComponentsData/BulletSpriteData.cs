using System;
using UnityEngine;

namespace Bullets.Components.ComponentsData
{
    [Serializable]
    public class BulletSpriteData : ComponentData
    {
        [field: SerializeField] public Sprite _sprite { get; private set;}

        protected override void SetComponentDependency()
        {
            _componentDependency = typeof(BulletSprite);
        }
    }
}