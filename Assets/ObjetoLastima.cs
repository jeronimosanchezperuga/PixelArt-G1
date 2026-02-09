using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoLastima : MonoBehaviour
{
    public float cantidadDaño;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SaludJugador saludJugador = collision.gameObject.GetComponent<SaludJugador>();
        PlayerKnockback knockback = collision.gameObject.GetComponent<PlayerKnockback>();
        if (saludJugador != null)
        {
            saludJugador.RecibirDanio((int)cantidadDaño);
            knockback?.ApplyKnockback(transform);
        }
    }
}
