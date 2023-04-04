using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    [SerializeField] private EffectAnim shootAnim;
    [SerializeField] private AudioClip[] shootAudio;
    private Quaternion rotationQuaternion;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void Shoot()
    {
        Vector3 barell = transform.GetChild(0).position;
        BulletSpawner.Instance.Shoot(barell ,rotationQuaternion);
        shootAnim.Play();
        AudioManager.Instance.PlaySFX(shootAudio[Random.Range(0, shootAudio.Length)], barell);
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 dir = MouseCursor.Instance.WorldMousePosition - (Vector2)transform.position ;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rotationQuaternion = Quaternion.Euler(0,0,angle);
        transform.localRotation = rotationQuaternion;
    }
}
