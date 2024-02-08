using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Statistics")]

    [SerializeField] private float speed;
    private Vector2 moveAmount;
    [SerializeField] private float sprintSpeedMultiplier;

    [Header("References")]
    private Rigidbody2D playerRigidBody;

    [SerializeField] private Animator playerMovementAnims;

    private bool hasStartedLeaning;

    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();

        if (playerRigidBody == null)
        {
            Debug.LogError("Player Rigidbody Component is not assigned in PlayerMovement script");
        }
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        moveAmount = moveInput.normalized * speed; //normalized used in order to prevent diagonal movement increasing speed
    
        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveAmount *= sprintSpeedMultiplier;
        }

        //transform.Translate(moveInput * Time.deltaTime);

        HandleAnimation(moveInput);
        HandleMovementLean(moveInput);
    }

    void HandleMovementLean(Vector2 moveInput)
    {

        float leanZRotation = 0f;
        float speedMultiplier = 1f;

        if(moveInput.y >  0)
        {
            leanZRotation = -70f;
        }
        else if(moveInput.y < 0)
        {
            leanZRotation = -110f;
        }
        else
        {
            leanZRotation = -90f;
            speedMultiplier = 2f;
        }

        Quaternion targetRoation = Quaternion.Euler(0, 0, leanZRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRoation, 4f * speedMultiplier * Time.deltaTime);
    }


    void HandleAnimation(Vector2 moveInput)
    {
        if(moveInput.y < 0)
        {
            playerMovementAnims.SetInteger("playerLeanDirection", 1);

            if(!hasStartedLeaning)
            {
                playerMovementAnims.SetBool("initialLean", true);

                hasStartedLeaning = true;

                playerMovementAnims.SetBool("initialLean", false);
            }
        }
        else if(moveInput.y > 0)
        {
            playerMovementAnims.SetInteger("playerLeanDirection", -1);
            if (!hasStartedLeaning)
            {
                playerMovementAnims.SetBool("initialLean", true);

                hasStartedLeaning = true;

                playerMovementAnims.SetBool("initialLean", false);
            }
        }
        else
        {
            playerMovementAnims.SetInteger("playerLeanDirection", 0);
            hasStartedLeaning = false;
        }
    }


    private void FixedUpdate()
    {
        playerRigidBody.position += moveAmount * Time.fixedDeltaTime;
    }
}
