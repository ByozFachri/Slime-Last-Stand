using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public MovementJoystick movementJoystick;
    bool isFacingRight = true;
    public float runSpeed = 5f;
    public AudioSource audioSFX;
    public AudioClip clip;
    public Animator animator;

    Vector2 moveDirection = Vector2.zero;

    private void Start()
    {
        audioSFX = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = movementJoystick.joystickVec;
        Flip();
    }

    private void FixedUpdate()
    {
        if(movementJoystick.joystickVec.y != 0)
        {
            body.velocity = new Vector2(moveDirection.x * runSpeed, moveDirection.y * runSpeed);
            if (body.velocity != Vector2.zero)
            {
                animator.SetBool("isWalking", true);

            }
        } else
        {
            body.velocity = Vector2.zero;
            animator.SetBool("isWalking", false);
        }
        
    }

    private void Flip()
    {
        if (isFacingRight && moveDirection.x < 0f || !isFacingRight && moveDirection.x > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "EnemyAttack")
        {
            if(hitInfo.transform.position.x > this.transform.position.x)
            {
                transform.position = transform.position - new Vector3(1f, 0f, 0f);
            }else
            {
                transform.position = transform.position + new Vector3(1f, 0f, 0f);
            }
            audioSFX.clip = clip;
            audioSFX.Play();
        }
    }
}
