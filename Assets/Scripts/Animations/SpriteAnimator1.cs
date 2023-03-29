using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimator1 : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private Sprite[] idleSprites;
    [SerializeField]
    private Sprite[] moveSprites;
    //this is an array for played animation
    private Sprite[] selectedArray;
    //actual animation, prevent switch to same animation
    private ANIMATION actualAnimation;
    private int currentFrame;
    private float timer;

    private const float FRAMERATE = .1f;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        //method is just as description, can be directly in awake
        selectedArray = idleSprites;
        SwitchFrame();
    }

    void Update()
    {
        //test SetAnimation will be called from character handler
        //parameter can be struct with all data about character and animator can decide what must show... but this is working and we must move next
        if(Input.GetKeyDown(KeyCode.F)) SetAnimation(ANIMATION.IDLE);
        if(Input.GetKeyDown(KeyCode.G)) SetAnimation(ANIMATION.WALK);
        //end test

        //timing can be same for all SpriteAnimators but its optimalization and not needed right now
        timer += Time.deltaTime;

        if (timer >= FRAMERATE)
        {
            timer -= FRAMERATE;
            currentFrame = (currentFrame + 1) % selectedArray.Length;
            SwitchFrame();
        }
    }

    private void SwitchFrame()
    {
        spriteRenderer.sprite = selectedArray[currentFrame];
    }

    public void SetAnimation(ANIMATION animationType)
    {
        if(actualAnimation == animationType) return;

        actualAnimation = animationType;
        currentFrame = 0;

        switch (animationType)
        {
            case ANIMATION.IDLE : selectedArray = idleSprites;
                break;
            case ANIMATION.WALK : selectedArray = moveSprites;
                break;
            default: break;
        }
        //show 1st sprite of animation
        SwitchFrame();
    }
    
}
public enum ANIMATION
    {
        IDLE,
        WALK
    }