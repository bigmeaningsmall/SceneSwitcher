using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to test loading between scenes using number keys
/// </summary>

public class SceneLoadingTester : MonoBehaviour
{
    
    //update function to check for input and load scenes
    void Update()
    {
        //check if developermode is active
        if (GameManager.instance.developerMode)
        {
            //check for input to load scenes
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                //load the main menu scene
                SceneLoader.instance.LoadScene(Enums.Scenes.MainMenu);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //load the options scene
                SceneLoader.instance.LoadScene(Enums.Scenes.Options);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //load the gameplay scene
                SceneLoader.instance.LoadScene(Enums.Scenes.Gameplay);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                //load the game over scene
                SceneLoader.instance.LoadScene(Enums.Scenes.GameOver);
            }
        }

    }
}
