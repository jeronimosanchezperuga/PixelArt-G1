using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJugador : MonoBehaviour
{
    Rigidbody2D playerRB;
    public float velocidad;
    public float fuerzaSalto;
    public Transform puntoSuelo;
    public bool enSuelo;
    public bool modoFlappyBird = false;
    public LayerMask capaSuelo;
    public Transform playerSprite;
    public Animator animator;
    public bool moviendose;
    public float radioDeteccionSuelo = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        enSuelo = Physics2D.OverlapCircle(puntoSuelo.position, radioDeteccionSuelo, capaSuelo);

        if ((enSuelo || modoFlappyBird) && playerRB != null && Input.GetKeyDown(KeyCode.W) || Input.GetButtonDown("upJump"))
        {
            playerRB.AddForce(Vector2.up * fuerzaSalto);
        }

        moviendose = (Mathf.Abs(Input.GetAxis("Horizontal")) > 0.1f);
        
                
        animator.SetFloat("Velocidad", Mathf.Abs(playerRB.velocity.x));
        animator.SetBool("Salta", !enSuelo);
    }
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        //if(moviendose)
        playerRB.velocity = new Vector2(x * velocidad, playerRB.velocity.y);

        if (playerRB.velocity.x < 0)
        {
            playerSprite.localScale = new Vector3(-1, 1, 1);
        }
        if (playerRB.velocity.x > 0)
        {
            playerSprite.localScale = new Vector3(1, 1, 1);
        }
    }
}
