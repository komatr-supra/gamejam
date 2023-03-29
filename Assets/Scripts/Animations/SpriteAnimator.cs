using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] spriteArray;
    private int currentFrame;
    private float timer;

    private const float FRAMERATE = 1f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= FRAMERATE) {
            timer -= FRAMERATE;
            currentFrame = (currentFrame + 1) % spriteArray.Length;
            spriteRenderer.sprite = spriteArray[currentFrame];
        }
    }
}
