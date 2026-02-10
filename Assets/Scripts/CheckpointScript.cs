using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
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

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (!puntoInicioTR)
        {
            Debug.LogError("No se encuentra punto de inicio. Asegúrate de que un objeto con la etiqueta 'Respawn' esté presente en la escena.");
            return;
        }
        if (col.gameObject.CompareTag("Player"))
        {
            puntoInicioTR.position = transform.position;
        }
    }
}
