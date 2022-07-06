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
    bool jump = false;
    public bool onStair = false;
    public float stairX;
    [SerializeField]
    private float stairSpeed;
    public float minY;
    public float maxY;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        float verticalMove = Input.GetAxis("Vertical") * stairSpeed;



        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (onStair && verticalMove != 0) 
        {            
            //ajustar la x del Player con la escalera
            //transform.position = new Vector3(stairX,transform.position.y,transform.position.z);
            if (transform.position.y > minY && transform.position.y < maxY)
            {
                transform.Translate(Vector3.up * verticalMove);
            }
            
        }
    }

    void FixedUpdate()
    {
        characterController.Move(horizontalMove * Time.deltaTime,false,jump);
        jump = false;
    }
}
