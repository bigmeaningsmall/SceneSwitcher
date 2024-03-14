using UnityEngine;
using UnityEngine.SceneManagement;

using Enums;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene("Scene-"+ scene.ToString());
        
        // switch (scene)
        // {
        //     case Scenes.MainMenu:
        //         SceneManager.LoadScene("Scene-"+ scene.ToString());
        //         break;
        //     case Scenes.Options:
        //         SceneManager.LoadScene("Scene-"+ scene.ToString());
        //         break;
        //     case Scenes.Gameplay:
        //         SceneManager.LoadScene("Scene-"+ scene.ToString());
        //         break;
        //     case Scenes.GameOver:
        //         SceneManager.LoadScene("Scene-"+ scene.ToString());
        //         break;
        // }
    }

}