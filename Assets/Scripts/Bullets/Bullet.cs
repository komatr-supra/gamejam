using System;
using Common;
using ScriptableObject;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    public BulletDataSO _data { get; private set; }
    public GameObject BulletSpriteObject { get; private set; }
    public GameObject WeaponSpriteObject { get; private set; }
    
    public GameObject _DamageDealer { get; private set; }

    public Transform firePoint { get; private set; }
    
    public void SetData(BulletDataSO data)
    {
        _data = data;
    }

    private void Awake()
    {
        BulletSpriteObject = transform.Find("BulletSprite").gameObject;
        WeaponSpriteObject = transform.Find("WeaponSprite").gameObject;
        firePoint = BulletSpawner.Instance._firePoint;
        _DamageDealer = transform.Find("DamageDealer").gameObject;
    }
}
