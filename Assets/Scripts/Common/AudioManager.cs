using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField] private AudioClip[] musicTracks;
    
    private AudioSource audioSource;
    private float _sfxVolume = 1;
    public float SfxVolume
    {
        get { return _sfxVolume; }
        set { _sfxVolume = value; }
    }
    
    private float _musicVolume = 0.2f;
    public float MusicVolume
    {
        get { return _musicVolume; }
        set { _musicVolume = value; audioSource.volume = _musicVolume;}
    }
    
    private void Awake() {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying) PlayRandomTrack();
    }

    private void PlayRandomTrack()
    {
        int rnd = UnityEngine.Random.Range(0, musicTracks.Length);
        audioSource.PlayOneShot(musicTracks[rnd], MusicVolume);
    }
    public void PlaySFX(AudioClip audioClip, Vector3 position)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, SfxVolume);
    }
}
