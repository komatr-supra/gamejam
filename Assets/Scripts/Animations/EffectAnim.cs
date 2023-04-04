using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectAnim : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private AudioClip[] effectSounds;
    [SerializeField] private bool isPermanent;
    [SerializeField] private bool isPlayingImmediately;
    private int index;
    private SpriteRenderer spriteRenderer;
    private AudioSource audioSource;
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Start() {
        if(isPlayingImmediately) Play();
    }
    public void Play()
    {
        if(effectSounds.Length > 0)
        {
            audioSource.clip = effectSounds[Random.Range(0, effectSounds.Length)];
            audioSource.volume = AudioManager.Instance.SfxVolume;
            audioSource.pitch = Random.Range(-1.6f, 1.5f);
            audioSource.Play();
        }
        index = 0;
        StartCoroutine(TimerCoroutine());
    }
    private IEnumerator TimerCoroutine()
    {
        while (index < sprites.Length)
        {
            spriteRenderer.sprite = sprites[index];
            yield return new WaitForSeconds(speed);
            index++;
        }
        if(isPermanent)
        {
            spriteRenderer.sprite = null;
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
