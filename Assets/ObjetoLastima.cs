using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoLastima : MonoBehaviour
{
    public float cantidadDaño;
    public Transform playerTR;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SaludJugador saludJugador = collision.gameObject.GetComponent<SaludJugador>();
        PlayerKnockback knockback = collision.gameObject.GetComponent<PlayerKnockback>();
        if (saludJugador != null)
        {
            saludJugador.RecibirDanio((int)cantidadDaño);
            knockback.ApplyKnockback(transform);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector2 direction = (playerTR.position - transform.position).normalized;
        Vector3 endpoint = transform.position + (Vector3) direction;
        Gizmos.DrawLine(transform.position,endpoint);
    }
}
