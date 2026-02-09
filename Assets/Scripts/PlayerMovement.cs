using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    CharacterController2D characterController;
    [SerializeField]
    Rigidbody2D rb;
    public float runSpeed = 40f;
    float horizontalMove;
    float verticalMove;
    bool jump = false;
    public bool onStair = false;
    public float stairX;
    [SerializeField]
    private float stairSpeed;
    public float minY;
    public float maxY;
    private bool crouch;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        verticalMove = Input.GetAxis("Vertical") * stairSpeed;

        if (Input.GetButtonDown("wJump"))
        {
            jump = true;
        }

        if (Input.GetButton("Crouch"))
        {
            crouch = true;
        }else
        {
            crouch = false;
        }

        if (onStair && verticalMove != 0)
        {
            //ajustar la x del Player con la escalera
            //transform.position = new Vector3(stairX,transform.position.y,transform.position.z);
            if (transform.position.y > minY && transform.position.y < maxY)
            {
                transform.Translate(Vector3.up * verticalMove);
                //TODO
                //reproducir la animacion de subir/bajar escalera
            }
        }
    }

    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.deltaTime,crouch,jump);
        jump = false;
    }
}
