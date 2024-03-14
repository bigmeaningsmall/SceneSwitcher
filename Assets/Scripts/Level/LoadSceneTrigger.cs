using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Enums;

/// <summary>
/// load a scene when the player enters a trigger
/// </summary>
public class LoadSceneTrigger : MonoBehaviour
{
    public Scenes sceneToLoad; //scene to load

    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the player enters the trigger
        if (other.CompareTag("Player"))
        {
            //load the scene
            SceneLoader.instance.LoadScene(sceneToLoad);
        }
    }
}

