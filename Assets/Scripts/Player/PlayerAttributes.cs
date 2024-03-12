using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// scriptable object example for a player attributes
/// to use this class we create an instance or variable of the class
/// use this class to create a wide variety of enemies with basic attributes
/// to use the class, create a new scriptable object in the assets folder, and set the variables in the inspector
/// to call the class, use the following code:
///     PlayerScriptableObject player = new EnemyScriptableObject();
///     player.enemyName = "player";
///     player.health = 100;
///     player.damage = 10;
///     player.speed = 5;
///     etc...
///     Debug.Log(player.playerName);
///     Debug.Log(player.health);
///     etc...
/// </summary>

[System.Serializable]
public class PlayerAttributes
{
    [Header("Player Attributes")]
    public string playerName;
    public int maxHealth;
    public int health;
    public int damage;
    public float speed;
    public float attackRange;
    public float attackCooldown;
    public float attackDuration;
    public float attackDelay;
    
    public PlayerAttributes(string playerName, int health, int damage, float speed, float attackRange, float attackCooldown, float attackDuration, float attackDelay)
    {
        this.playerName = playerName;
        this.health = health;
        this.damage = damage;
        this.speed = speed;
        this.attackRange = attackRange;
        this.attackCooldown = attackCooldown;
        this.attackDuration = attackDuration;
        this.attackDelay = attackDelay;
    }
}
