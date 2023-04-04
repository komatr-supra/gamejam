using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    public static MouseCursor Instance;
    private Vector2 cursorPosition;
    public Vector2 WorldMousePosition
    {
        get { return cursorPosition; }
        private set { cursorPosition = value; }
    }
    private Camera cam;
    private void Awake() {
        Cursor.visible = false;
        if(Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    void Start()
    {
        cam = Camera.main;
    }

    
    void Update()
    {
        cursorPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = cursorPosition;
    }
}
