using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// damage or heal the player when the player enters a trigger
/// </summary>

public class HealthModifier : MonoBehaviour
{
    [Range(-5,5)]
    public int healthChange; //amount to change the player's health by

    private Player player; //the player script
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        //if the player enters the trigger
        if (other.CompareTag("Player"))
        {
            //chec if the player has the script 'player' amd get the player script if so
            if (other.GetComponent<Player>()){
                player = other.GetComponent<Player>();
            }
            else {
                Debug.LogError("Player script not found!");
            }
            
            //change the player's health
            player.ChangePlayerHealth(healthChange);
        }
    }
}
