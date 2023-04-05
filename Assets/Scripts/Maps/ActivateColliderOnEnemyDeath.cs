using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivateColliderOnEnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject colliderObject; // The collider object to activate
    public GameObject[] enemies; // Array of enemy objects in the scene
    public GameObject doorClosed; // Array of enemy objects in the scene

    public void LoadScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    private void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Debug.Log($"enemies numb: {enemies.Length}");

        // Activate the collider object if all enemies are dead
        if (enemies.Length == 0)
        {
            colliderObject.SetActive(true);
            doorClosed.SetActive(false);
        }
    }
}
