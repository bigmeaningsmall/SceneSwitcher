using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Scene-MainMenu");
    }

    public void LoadOptionsScene()
    {
        SceneManager.LoadScene("Scene-Options");
    }

    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("Scene-Gameplay");
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("Scene-GameOver");
    }
}