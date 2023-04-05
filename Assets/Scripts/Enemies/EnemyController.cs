using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log($"Collision: {other.collider}");
        GetComponent<EffectAnim>().Play();

        Destroy(gameObject, 0.5f);
    }

}
