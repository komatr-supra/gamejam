using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScriptableObject
{
    [CreateAssetMenu(fileName = "newBulletData", menuName = "Data/Bullet Data", order = 0)]
    public class BulletDataSO : UnityEngine.ScriptableObject
    {
        [field: SerializeReference] public List<ComponentData> _componentData { get; private set; }

        public T GetData<T>()
        {
            return _componentData.OfType<T>().FirstOrDefault();
        }

        public List<Type> GetAllDependencies()
        {
            return _componentData.Select(_component => _component._componentDependency).ToList();
        }

        public void AddData(ComponentData data)
        {
            if (_componentData.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            {
                return;
            }
            
            _componentData.Add(data);
        }
    }
}