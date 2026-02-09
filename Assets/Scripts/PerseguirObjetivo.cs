using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerseguirObjetivo : MonoBehaviour
{
    public float velocidadPersecucion;
    public Transform objetivo;
    public PatrullajeVolador patrullaje;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        patrullaje = GetComponent<PatrullajeVolador>();
        if (patrullaje)
        {
            patrullaje.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (objetivo == null)
            return;
        Vector2 direction = (objetivo.position - transform.position).normalized;
        rb.velocity = direction * velocidadPersecucion;

    }
}
