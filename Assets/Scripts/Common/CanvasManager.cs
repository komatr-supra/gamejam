using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private AudioClip testSFX;
    private Coroutine coroutine;
    public void ChangeSFXVolume(float newVolume)
    {
        AudioManager.Instance.SfxVolume = newVolume;
        if(coroutine != null) StopAllCoroutines();
        coroutine = StartCoroutine(PlayTestSFX());
    }
    public void ChangeAudioVolume(float newVolume)
    {
        AudioManager.Instance.MusicVolume = newVolume;
    }
    private IEnumerator PlayTestSFX()
    {
        yield return new WaitForSeconds(0.1f);
        AudioManager.Instance.PlaySFX(testSFX, Camera.main.transform.position);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
