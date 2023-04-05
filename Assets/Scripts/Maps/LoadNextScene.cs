using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    private const string LAST_MAP_SCENE = "Map04";
    public void LoadScene()
    {
        // Get the current scene index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        Debug.Log($"Total number of Scenes: {SceneManager.sceneCountInBuildSettings}");
        Debug.Log($"Scene name: {SceneManager.GetActiveScene().name}");

        if (SceneManager.GetActiveScene().name == LAST_MAP_SCENE) {
            SceneManager.LoadScene("EndScene");
        } else {
            // Load the next scene
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        LoadScene();
    }
}
