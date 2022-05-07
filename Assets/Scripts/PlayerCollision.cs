using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = gameObject.transform.parent.GetComponent<PlayerMovement>();
    }
    void OnCollisionEnter(UnityEngine.Collision collision)
    {
        // Check if the collision was with an object on the ground layer
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground Layer"))
        {
            animator.SetBool("isGrounded", true);
            // Change the jumpInput variable in PlayerMovement script once character lands
            playerMovement.jumpInput = false;
        }
    }
}
