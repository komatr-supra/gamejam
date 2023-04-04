using System;
using UnityEngine;

namespace Common
{
    public class DamageReceiver : MonoBehaviour
    {
        [SerializeField] protected float hp;
        [SerializeField] protected float hpMax;

        protected void Start()
        {
            HealAll();
        }

        public virtual void HealAll()
        {
            this.hp = this.hpMax;
        }

        public virtual void Add(float amount)
        {
            this.hp += amount;
            if (this.hp > this.hpMax) this.hp = this.hpMax;
        }

        public virtual void Deal(float amount)
        {
            this.hp -= amount;
            if (this.hp < 0) this.hp = 0;
        }

        public virtual bool IsDead()
        {
            if (this.hp <= 0) return true;
            return false;
        }
    }
}