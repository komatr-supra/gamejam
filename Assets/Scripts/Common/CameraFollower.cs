using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform followingObject;
    private Camera cam;
    void Start()
    {
        followingObject = FindObjectOfType<PlayerInputHandler>().transform;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(followingObject.position.x, followingObject.position.y, transform.position.z);
    }
}
