using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarNivel : MonoBehaviour
{
    public Transform puntoInicio;

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Choco");
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.position = puntoInicio.position;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        } 

    }
}
