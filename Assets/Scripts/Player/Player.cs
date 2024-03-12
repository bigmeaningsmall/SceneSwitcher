using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// an example of a player class
/// </summary>

public class Player : MonoBehaviour
{
    private GameManager gameManager; //GET A REFERENCE TO THIS SO WE CAN ACCESS THE PLAYERS ATTRIBUTES

    [Header("Player Health and Attributes")]
    public PlayerAttributes playerAttributes;

    void Start()
    {
        //get the instance of GameManager for use in this script but check if it exists first
        if (GameManager.instance != null) {
            //get the instance of GameManager
            gameManager = GameManager.instance;
            Debug.Log("GameManager found! " + " - Current State: " + gameManager.CurrentGameState.ToString());
            InitialisePlayer();
        }
        else {
            Debug.Log("GameManager not found!");
        }
    }
    private void InitialisePlayer()
    {
        //get the players attributes from the game manager
        playerAttributes = gameManager.PlayerAttributes;
        Debug.Log("Initialise Player: " + playerAttributes.playerName + " - Health: " + playerAttributes.health);
    }
    
    //an example of how to change the players health - call this public function to take damage
    public void ChangePlayerHealth(int newHealth)
    {
        //change the players health by updating the players health attribute
        playerAttributes.health = playerAttributes.health+newHealth;
        SetPlayerAttributes();
    }
    
    //--  getters and setters  ---------------------------------------------------------
    // getthe players attributes
    public PlayerAttributes GetPlayerAttributes()
    {
        return playerAttributes;
    }
    
    //set the players attributes to the game manager
    private void SetPlayerAttributes()
    {
        //set the players attributes to the game manager
        gameManager.PlayerAttributes = playerAttributes;
    }

}
