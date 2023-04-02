using System;
using UnityEngine;

namespace Bullets.Components.ComponentsData
{
    [Serializable]
    public class BulletDespawnedData : ComponentData
    {
        [field: SerializeField] public int distance { get; private set; }
        [field: SerializeField] public int _numberUnitCanGoThrough { get; private set; }

        protected override void SetComponentDependency()
        {
            _componentDependency = typeof(BulletDespawned);
        }
    }
}