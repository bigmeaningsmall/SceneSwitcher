using UnityEngine;
using System.Collections;

/// <summary>
/// a 2d topdown player movement script
/// controls rigidbody 2d
/// adds acceleration and deceleration
/// </summary>

public class PlayerMovement : MonoBehaviour 
{
    [Header("Player Movement")]
    public float maxSpeed = 5f; //max speed
    public float acceleration = 0.2f; //acceleration
    public float deceleration = 0.2f; //deceleration
    
    public float currentSpeed; //current speed
    public Vector2 moveDirection; //move direction
    
    private Rigidbody2D rb; //rigidbody 2d

    void Start()
    {
        //get the rigidbody 2d
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //get the move direction
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");
        moveDirection.Normalize();
    }

    void FixedUpdate()
    {
        //move the player
        MovePlayer(moveDirection);
    }

    void MovePlayer(Vector2 direction)
    {
        //if the player is moving
        if (direction.magnitude >= 0.1f)
        {
            //add acceleration
            currentSpeed = Mathf.Clamp(currentSpeed + acceleration, 0, maxSpeed);
        }
        else
        {
            //add deceleration
            currentSpeed = Mathf.Clamp(currentSpeed - deceleration, 0, maxSpeed);
        }

        //move the player
        rb.velocity = direction * currentSpeed;
    }

}
