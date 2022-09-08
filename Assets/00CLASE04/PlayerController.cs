using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float fuerzaAvance;
    public float fuerzaSalto;
    public Rigidbody2D rb;
    public Transform tr;
    public bool estaEnElPiso;
    public LayerMask layer;
    public float fuerzaAvanceEnElAire;
    public float fuerzaAvanceEnElPiso;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float movX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(movX*fuerzaAvance, rb.velocity.y);

        Vector3 escalaActual = tr.localScale;
        if (movX > 0)
        {
            escalaActual.x = 1;
            tr.localScale = escalaActual;
        }
        if (movX <0)
        {
            escalaActual.x = -1;
            tr.localScale = escalaActual;
        }

        if (Input.GetKeyDown(KeyCode.W) && estaEnElPiso)
        {
            rb.AddForce(Vector2.up * fuerzaSalto,ForceMode2D.Impulse);
        }

        estaEnElPiso = Physics2D.OverlapCircle(tr.position, 0.5f, layer);
        //if (!estaEnElPiso)
        //{
        //    fuerzaAvance = fuerzaAvanceEnElAire;
        //}
        //else
        //{
        //    fuerzaAvance = fuerzaAvanceEnElPiso;
        //}

    }

}
