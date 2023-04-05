using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float enemySpeed = 1.2f;
    [SerializeField]
    private GameObject testPathfinding;
    private Pathfinding pathfinding;
    private GameObject player;
    private Rigidbody2D rb2d;

    private float threshold = 1.0f;
    private Vector3 lastPosition;
    private List<Vector3> pathToPlayer;

    private void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        pathfinding = testPathfinding.GetComponent<TestingPathfinding>().getPathfinding();
        player = GameObject.FindGameObjectWithTag("Player");
        lastPosition = player.transform.position;
        pathToPlayer = pathfinding.findPath(transform.position, lastPosition);
    }

    private void Update() {
        Vector3 offset = player.transform.position - lastPosition;
        if (offset.x > threshold) {
            lastPosition = player.transform.position;
            pathToPlayer = pathfinding.findPath(transform.position, lastPosition);
        }
        for (int i = 0; i < pathToPlayer.Count; i++) {
            rb2d.MovePosition(Vector3.MoveTowards(transform.position, pathToPlayer[i], enemySpeed * Time.fixedDeltaTime));
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Bullet")) {
            GetComponent<EffectAnim>().Play();

            Destroy(gameObject, 0.5f);
        }
    }

}
