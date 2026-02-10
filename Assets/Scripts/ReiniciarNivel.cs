using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReiniciarNivel : MonoBehaviour
{
    public Transform puntoInicioTR;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        puntoInicioTR = GameObject.FindGameObjectWithTag("Respawn").transform;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!puntoInicioTR)
        {
            Debug.LogError("No se encuentra punto de inicio. Asegúrate de que un objeto con la etiqueta 'Respawn' esté presente en la escena.");
            return;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
            rb.MovePosition(puntoInicioTR.position);
        }
    }
}
