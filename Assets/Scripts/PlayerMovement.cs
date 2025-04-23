using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float flySpeed = 5f;
    [SerializeField] private float maxFlyHeight = 3f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask platformLayer;
    [SerializeField] private Transform feetPos;
    [SerializeField] private float groundDistance = 0.25f;
    [SerializeField] private float jumpTime = 0.3f;
    private bool isGrounded = false;
    private bool isPlatformed = false;
    private bool isJumping = false;
    private float jumpTimer;
    private float initialY;
    GameManager gm;
    public bool fallThrough;
    [SerializeField] public PlatformEffector2D platformEffector2D_1;
    [SerializeField] public PlatformEffector2D platformEffector2D_2;

    private void Start()
    {
        gm = GameManager.Instance;
        initialY = transform.position.y;
    }

    private void Update()
    {
        if (gm.isFly)
        {
            rb.gravityScale = 0;
            
            float verticalInput = 0;
            
            if (Keyboard.current.upArrowKey.isPressed)
            {
                if (transform.position.y < initialY + maxFlyHeight)
                {
                    verticalInput = 1;
                }
                else
                {
                    verticalInput = 0;
                }

                platformEffector2D_1.rotationalOffset = 0;
                platformEffector2D_2.rotationalOffset = 0;
            }
            else if (Keyboard.current.downArrowKey.isPressed)
            {
                verticalInput = -1;
                platformEffector2D_1.rotationalOffset = 180;
                platformEffector2D_2.rotationalOffset = 180;
            }
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, verticalInput * flySpeed);
        }
        else
        {
            rb.gravityScale = 5;
            
            isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);
            isPlatformed = Physics2D.OverlapCircle(feetPos.position, groundDistance, platformLayer);

            if(Keyboard.current.downArrowKey.isPressed)
            {
                platformEffector2D_1.rotationalOffset = 180;
                platformEffector2D_2.rotationalOffset = 180;
            }
            else
            {
                platformEffector2D_1.rotationalOffset = 0;
                platformEffector2D_2.rotationalOffset = 0;
            }
         
            if ((isGrounded || isPlatformed || gm.doubleJump) && Input.GetButtonDown("Jump")) {
                
                if (!isGrounded && !isPlatformed){
                    gm.doubleJump = false;
                }
                isJumping = true;
                rb.linearVelocity = Vector2.up * jumpForce;
            }

            if (isJumping && Input.GetButton("Jump"))
            {
                if (jumpTimer < jumpTime)
                {
                    rb.linearVelocity = Vector2.up * jumpForce;
                    jumpTimer += Time.deltaTime;
                }
                else
                {
                    isJumping = false;
                }
            }

            if (Input.GetButtonUp("Jump"))
            {
                isJumping = false;
                jumpTimer = 0;
            }
            
            if (isGrounded || isPlatformed)
            {
                initialY = transform.position.y;
            }
        }
    }

    private void OnDisable()
    {
        if (rb != null)
        {
            rb.gravityScale = 5;
        }
    }
}
