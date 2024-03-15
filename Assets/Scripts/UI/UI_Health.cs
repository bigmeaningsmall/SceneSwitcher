using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Display the player health on the UI canvas as both a number and a bar
/// this class subscribes tp the player modified event and updates the health bar and text when the player's health changes
/// </summary>

public class UI_Health : MonoBehaviour
{
    //health bar and text
    public Slider healthBar;
    public TextMeshProUGUI healthText;
    
    private int maxHealth; //the player's max health
    private int currentHealth; //the player's current health
    

    #region Subscriptions

    private void OnEnable(){
        //subscribe to the player modified event
        Player.OnPlayerModified += OnPlayerModified;
    }

    private void OnDisable(){
        //unsubscribe from the player modified event
        Player.OnPlayerModified -= OnPlayerModified;
    }

    private void OnPlayerModified(PlayerAttributes playerAttributes){
        maxHealth = playerAttributes.maxHealth;
        currentHealth = playerAttributes.health;
    }

    #endregion

    #region UI Update
    
    private void Update(){
        //update the health text
        healthText.text = "Health: " + currentHealth.ToString() + " / " + maxHealth.ToString();
        
        //TODO - update the health bar value as a percentage of the player's health
        //update the health bar value as a percentage of the player's health
        ///healthBar.value = (float)currentHealth / (float)maxHealth;
        
    }

    #endregion
}
