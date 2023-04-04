using System;
using Bullets.Components;
using Bullets.Components.ComponentsData;
using UnityEngine;

public class BulletSprite : BulletComponent<BulletSpriteData>
{
    private SpriteRenderer _bulletSpriteRenderer;
    private SpriteRenderer _weaponSpriteRenderer;

    protected override void Awake()
    {
        base.Awake();
        //Fix when create weapon data;
        _bulletSpriteRenderer = _bullet.BulletSpriteObject.GetComponent<SpriteRenderer>();
        _weaponSpriteRenderer = _bullet.WeaponSpriteObject.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _bulletSpriteRenderer.sprite = _componentData._sprite;
    }
}
