using System;
using System.Collections.Generic;
using System.Linq;
using Bullets.Components;
using ScriptableObject;
using UnityEngine;

namespace Bullets
{
    public class BulletGenerator : MonoBehaviour
    {
        [SerializeField] private Bullet _bullet;
        [SerializeField] private BulletDataSO _bulletDataSo;

        private List<BulletComponent> componentAlreadyOnBullet = new List<BulletComponent>();

        private List<BulletComponent> componentAddedToBullet = new List<BulletComponent>();

        private List<Type> componentDependencies = new List<Type>();

        private void Start()
        {
            GenerateBullet(_bulletDataSo);
        }

        public void GenerateBullet(BulletDataSO data)
        {
            _bullet.SetData(data);
            componentAlreadyOnBullet.Clear();
            componentAlreadyOnBullet.Clear();
            componentDependencies.Clear();

            componentAlreadyOnBullet = GetComponents<BulletComponent>().ToList();

            componentDependencies = data.GetAllDependencies();
            
            foreach (var dependency in componentDependencies)
            {
                if (componentAddedToBullet.FirstOrDefault(component => component.GetType() == dependency)) continue;

                var bulletComponent =
                    componentAlreadyOnBullet.FirstOrDefault(component => component.GetType() == dependency);

                if (bulletComponent == null)
                {
                    bulletComponent = gameObject.AddComponent(dependency) as BulletComponent;
                }
                
                bulletComponent.Init();
                
                componentAddedToBullet.Add(bulletComponent);

            }

            var componentsToRemove = componentAlreadyOnBullet.Except(componentAddedToBullet);

            foreach (var bulletComponent in componentsToRemove)
            {
                Destroy(bulletComponent);
            }
        }
    }
}