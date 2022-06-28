using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController2D characterController;
    public float runSpeed = 40f;
    float horizontalMove;
    bool jump = false;
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.deltaTime,false,jump);
        jump = false;
    }
}
