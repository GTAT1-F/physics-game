using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] Transform transform;
    [SerializeField] Animator animator;

    private Vector3 movement;
    private float speed = 8f;
    private float jumpForce = 12f;

    private float horizontalInput;
    private bool attackInput;
    public bool jumpInput;

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpInput = true;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            attackInput = true;
        }
    }

    private void FixedUpdate()
    {
        movement = new Vector3(horizontalInput, 0, 0);
        bool isGrounded = animator.GetBool("isGrounded");

        // Rotates the character to face in the horizontal input direction
        if(horizontalInput != 0)
        {
            Quaternion rotation = Quaternion.LookRotation(movement);
            rigidBody.MoveRotation(rotation);
        }

        if (jumpInput && isGrounded)
        {
            Jump();
        }
        if (attackInput)
        {
            Attack();
        }
        // Don't move horizontally while punching
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Punching"))
        {
            movement.x = 0;
        }
        // Transtion between running and idle animation
        animator.SetFloat("speed", Mathf.Abs(movement.x));

        movement *= Time.deltaTime * speed;
        rigidBody.MovePosition(transform.position + movement);
        
    }

    private void Jump()
    {
        rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        animator.SetBool("isGrounded", false);
    }


    private void Attack()
    {
        animator.SetTrigger("isAttacking");
        attackInput = false;
    }

}
