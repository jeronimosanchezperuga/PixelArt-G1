using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectarObjetivoYSeguir : MonoBehaviour
{
    public PerseguirObjetivo perseguirObjetivoScript;


    // Start is called before the first frame update
    void Awake()
    {
        perseguirObjetivoScript = GetComponentInParent<PerseguirObjetivo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Jugador detectado, siguiendo...");
            // Aquí puedes agregar la lógica para seguir al jugador
            if (perseguirObjetivoScript != null)
            {
                perseguirObjetivoScript.enabled = true;
            }

        }
    }
}
