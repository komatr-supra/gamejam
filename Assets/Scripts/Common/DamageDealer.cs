using UnityEngine;

namespace Common
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField]
        public float _damage
        {
            get => damage;
            set
            {
                damage = value;
            }
        }

        private float damage;
        
        public virtual void DealDame(Transform obj)
        {
            DamageReceiver damageReceiver;
            damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
            if (damageReceiver == null) return;
            this.DealDame(damageReceiver);
        }

        public virtual void DealDame(DamageReceiver damageReceiver)
        {
            damageReceiver.Deal(damage);
            DestroyObject();
        }

        protected virtual void DestroyObject()
        {
            Destroy(transform.parent.gameObject);
        }
        
    }
}