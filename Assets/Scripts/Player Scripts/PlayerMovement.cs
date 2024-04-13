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
    [SerializeField] private ParticleSystem thrustersParticles; // Reference to the Particle System

    private bool hasStartedLeaning;

    [SerializeField] AudioSource thrustersAudioSource;

    private bool isFacingRight = true; // Track the direction the player is facing

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
            AdjustThrustersSound(true); // Increase thrusters sound
            if (!thrustersParticles.isPlaying)
            {
                thrustersParticles.Play(); // Start emitting particles
            }
        }
        else
        {
            AdjustThrustersSound(false); // Reset or decrease thrusters sound
            if (thrustersParticles.isPlaying)
            {
                thrustersParticles.Stop(); // Stop emitting particles
            }
        }

        //if (moveInput.x > 0 && !isFacingRight)
        //{
        //    // Player moving right and is currently facing left
        //    FlipCharacter();
        //}
        //else if (moveInput.x < 0 && isFacingRight)
        //{
        //    // Player moving left and is currently facing right
        //    FlipCharacter();
        //}

        //transform.Translate(moveInput * Time.deltaTime);

        HandleAnimation(moveInput);
        HandleMovementLean(moveInput);
    }


    void AdjustThrustersSound(bool isSprinting)
    {
        if (isSprinting)
        {
            thrustersAudioSource.pitch = Mathf.Lerp(thrustersAudioSource.pitch, 1.5f, Time.deltaTime * 5); // or use a volume increase if preferred
            thrustersAudioSource.volume = Mathf.Lerp(thrustersAudioSource.volume, .45f, Time.deltaTime * 5); // adjust max volume as needed

        }
        else
        {
            thrustersAudioSource.pitch = Mathf.Lerp(thrustersAudioSource.pitch, 1f, Time.deltaTime * 5); // return to normal pitch
            thrustersAudioSource.volume = Mathf.Lerp(thrustersAudioSource.volume, .125f, Time.deltaTime * 5); // adjust normal volume as needed


        }
    }

    void HandleMovementLean(Vector2 moveInput)
    {
        float leanZRotation = 0f;
        float speedMultiplier = 1f;

        if (moveInput.y > 0)
        {
            leanZRotation = isFacingRight ? -70f : 250f; // 250f is 360f - 110f, adjusting for full rotation
        }
        else if (moveInput.y < 0)
        {
            leanZRotation = isFacingRight ? -110f : 290f; // 290f is 360f - 70f, adjusting for full rotation
        }
        else
        {
            leanZRotation = isFacingRight ? -90f : -90f; // No change needed for neutral position
            speedMultiplier = 2f;
        }

        Quaternion targetRotation = Quaternion.Euler(0, 0, leanZRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 4f * speedMultiplier * Time.deltaTime);
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



    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight; // Update the direction the player is facing
        Vector3 theScale = transform.localScale;
        theScale.y *= -1; // Flip the y scale

        transform.localScale = theScale;
    }


}
