using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0, 0);
      controller.Move(move * Time.deltaTime * playerSpeed);
      if (Input.GetKeyDown(KeyCode.D))
      {
          gameObject.transform.forward = move;
      }


    }
}
