using System.Collections;
using System.Collections.Generic;
using UnityEngine;


#region Game State
public enum GameState
{
    Battling,
    MainMenu,
    Options,
    Paused,
    Gameplay,
    GameOver
}
#endregion


public class GameManager : MonoBehaviour
{
    [Header("Current Game State and Status")]
    public GameState CurrentGameState = GameState.Gameplay; // current game state
    public bool OverworldRunning = false; 
    
    public static GameManager instance;
    
    [Space(10)] 
    [Header("Player Health and Attributes")] 
    //Player attributes
    [SerializeField] float playerMaxHealth = 10;
    [SerializeField] public float playerCurrentHealth = 10;

    [Header("Debugging")]
    public bool developerMode = true; //set true to enable developer settings
    
    #region Initialise
    void Awake()
    {
        //set the instance of GameManager to this instance and make it persist between scenes
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    #endregion

    #region GameStates
    private void Gameplay()
    {
        OverworldRunning = true;
    }
    private void GameOver()
    {
        OverworldRunning = false;
    }
    private void Battling()
    {
        OverworldRunning = false;
    }
    private void MainMenu()
    {
        OverworldRunning = false;
    }
    private void Options()
    {
        OverworldRunning = false;
    }
    private void Paused()
    {
        OverworldRunning = false;
    }

    // Method to change the game state - call this to change the game state
    public void ChangeGameState(GameState newGameState)
    {
        CurrentGameState = newGameState;
        if (CurrentGameState == GameState.MainMenu)
        {
            MainMenu();
        }
        if (CurrentGameState == GameState.Gameplay)
        {
            Gameplay();
        }
        
    }
    #endregion

    #region Static Variables
    
    //public 

    #endregion

    //get and set the players health - call from other scripts to add health, take damage and check health
    //health can be greater than max health
    public float PlayerCurrentHealth
    {
        get
        {
            return playerCurrentHealth;
        }
        set 
        { 
            if (value > playerMaxHealth)
            {
                playerCurrentHealth = playerMaxHealth;
            }
            else
            {
                playerCurrentHealth = value; 
            }
        }
    }
    
}
