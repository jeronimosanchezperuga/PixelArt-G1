using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class PatrullajeVolador: MonoBehaviour
{
    public float speed;
    public bool idaYVuelta = false;
    public bool yendoDeIda = true;
    public Transform[] Destinos;
    public Rigidbody2D rb;

    private int destinoActualIndex = 0;
        
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.gravityScale = 0f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        Vector2 direccion = transform.position - Destinos[destinoActualIndex].position;
        rb.velocity = direccion.normalized * speed * -1;
        float distance = Vector2.Distance(transform.position, Destinos[destinoActualIndex].position);
        if (!idaYVuelta)
        {
            if (distance < 0.1f)
            {
                destinoActualIndex++;
                if (destinoActualIndex >= Destinos.Length)
                {
                    destinoActualIndex = 0;
                }
            }
        }
        else if (yendoDeIda)
        {
            if (distance < 0.1f)
            {
                destinoActualIndex++;
                if (destinoActualIndex >= Destinos.Length)
                {
                    yendoDeIda = false;
                    destinoActualIndex = Destinos.Length - 1;
                }
            }
        }
        else
        {
            if (distance < 0.1f)
            {
                destinoActualIndex--;
                if (destinoActualIndex < 0)
                {
                    yendoDeIda = true;
                    destinoActualIndex = 0;
                }
            }
        }

       if(rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

    }

    void OnDrawGizmos()
    {
        if (Destinos.Length > 0)
        {
            for (int i = 0; i < Destinos.Length; i++)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(Destinos[i].position, 0.2f);
                Gizmos.color = Color.green;
                if (i + 1 < Destinos.Length)
                {
                    Gizmos.DrawLine(Destinos[i].position, Destinos[i + 1].position);
                }
                else if(!idaYVuelta)
                {
                    Gizmos.DrawLine(Destinos[i].position, Destinos[0].position);
                }
            }
        }
    }
}
