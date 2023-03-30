using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Action[] onAnimationTick;
    private float timer;
    private int actionIndex;
    private int actionIndexForAdd;
    private const float FRAMERATE = .2f;
    private readonly float fakeFramerate = FRAMERATE / 3;
    private void Awake() {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        onAnimationTick = new Action[3];
        Instance = this;
    }
    private void Update() {
        //timing can be same for all SpriteAnimators but its optimalization and not needed right now
        timer += Time.deltaTime;

        if (timer >= fakeFramerate)
        {
            timer -= fakeFramerate;
            
            onAnimationTick[actionIndex]?.Invoke();
            actionIndex = ++actionIndex < onAnimationTick.Length ? actionIndex : 0;
        }
    }
    public void SubscribeAnimationEvent(Action action)
    {
        onAnimationTick[actionIndexForAdd] += action;
        actionIndexForAdd = ++actionIndexForAdd < onAnimationTick.Length ? actionIndexForAdd : 0;
    }
}
