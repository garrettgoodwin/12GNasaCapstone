using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPlayer : MonoBehaviour
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

        if (thrustersParticles == null)
        {
            Debug.LogError("Thrusters Particle System is not assigned in the script");
        }
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        moveAmount = moveInput.normalized * speed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveAmount *= sprintSpeedMultiplier;
            AdjustThrustersSound(true);
            if (!thrustersParticles.isPlaying)
            {
                thrustersParticles.Play(); // Start emitting particles
            }
        }
        else
        {
            AdjustThrustersSound(false);
            if (thrustersParticles.isPlaying)
            {
                thrustersParticles.Stop(); // Stop emitting particles
            }
        }

        if (moveInput.x > 0 && !isFacingRight)
        {
            // Player moving right and is currently facing left
            FlipCharacter();
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            // Player moving left and is currently facing right
            FlipCharacter();
        }

        HandleAnimation(moveInput);
        HandleMovementLean(moveInput);
    }

    void AdjustThrustersSound(bool isSprinting)
    {
        thrustersAudioSource.pitch = Mathf.Lerp(thrustersAudioSource.pitch, isSprinting ? 1.5f : 1f, Time.deltaTime * 5);
        thrustersAudioSource.volume = Mathf.Lerp(thrustersAudioSource.volume, isSprinting ? .45f : .125f, Time.deltaTime * 5);
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
        int leanDirection = moveInput.y > 0 ? -1 : moveInput.y < 0 ? 1 : 0;
        playerMovementAnims.SetInteger("playerLeanDirection", leanDirection);

        if (leanDirection != 0 && !hasStartedLeaning)
        {
            playerMovementAnims.SetBool("initialLean", true);
            hasStartedLeaning = true;
        }
        else if (leanDirection == 0)
        {
            hasStartedLeaning = false;
        }

        playerMovementAnims.SetBool("initialLean", false);
    }

    private void FixedUpdate()
    {
        playerRigidBody.MovePosition(playerRigidBody.position + moveAmount * Time.fixedDeltaTime);
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight; // Update the direction the player is facing
        Vector3 theScale = transform.localScale;
        theScale.y *= -1; // Flip the y scale

        transform.localScale = theScale;
    }
}
