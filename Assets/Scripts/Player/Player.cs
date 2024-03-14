using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
/// an example of a player class
/// </summary>

public class Player : MonoBehaviour
{
    private GameManager gameManager; //GET A REFERENCE TO THIS SO WE CAN ACCESS THE PLAYERS ATTRIBUTES etc...

    [Header("Player Health and Attributes")]
    public PlayerAttributes playerAttributes; //player attributes - scriptable object

    #region Events

    //delegate event to broadcast the player state (send the player attributes within the event)
    public delegate void PlayerModified(PlayerAttributes playerAttributes);
    public static event PlayerModified OnPlayerModified;
    

    #endregion

    #region Initialisation
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
        //get the players attributes from the game manager - THIS WILL BE USED TO LOAD BETWEEN SCENES OR FROM SAVE FILES
        playerAttributes = gameManager.PlayerAttributes;
        Debug.Log("Initialise Player: " + playerAttributes.playerName + " - Health: " + playerAttributes.health);
        
        //BROADCAST the player attributes to the event
        if(OnPlayerModified != null)
        {
            OnPlayerModified(playerAttributes);
        }
    }

    #endregion

    #region Public Functions
    
    //an example of how to change the players health - call this public function with minus to take damage or positive to add health
    public void ChangePlayerHealth(int healthModifier)
    {        
        //if the healthModifier is positive then flash the player material blue
        if (healthModifier > 0)
        {
            //flash the player material blue
            StartCoroutine(FlashPlayerMaterial(Color.cyan));
        }

        if (healthModifier < 0)
        {
            //flash the player material red
            StartCoroutine(FlashPlayerMaterial(Color.red));
        }
        
        //change the players health by updating the players health attribute with the passed in modifier
        playerAttributes.health = playerAttributes.health  + healthModifier;
        
        //check if the player health is less than or equal to 0 or greater than or equal to the max health or between
        if (playerAttributes.health <= 0)
        {
            playerAttributes.health = 0;
            //if the player health is less than or equal to 0 then the player is dead
            Debug.Log("Player is dead!");
        }
        else if (playerAttributes.health >= playerAttributes.maxHealth)
        {
            playerAttributes.health = playerAttributes.maxHealth;
            //if the player health is greater than or equal to the max health then the player is at full health
            Debug.Log("Player is at full health!");
        }
        
        
        //update the game manager with the new players attributes
        SetPlayerAttributes();
        
        //BROADCAST the player attributes to the event
        if(OnPlayerModified != null)
        {
            OnPlayerModified(playerAttributes);
        }
    }

    #endregion


    #region Effects

    private IEnumerator FlashPlayerMaterial(Color colour)
    {
        //get the player sprite renderer
        SpriteRenderer playerSpriteRenderer = GetComponent<SpriteRenderer>();
        
        //set the player material to blue
        playerSpriteRenderer.material.color = colour;
        
        //wait for 0.1 seconds
        yield return new WaitForSeconds(0.1f);
        
        //set the player material back to white
        playerSpriteRenderer.material.color = Color.white;
    }

    #endregion


    #region Getters and Setters
    //--  getters and setters  ---------------------------------------------------------
    // get the players attributes
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
    #endregion
    


}
