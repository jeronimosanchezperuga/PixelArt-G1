using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public Transform puntoInicioTR;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.gameObject.CompareTag("Player"))
        {
            puntoInicioTR.position = transform.position;
        }
    }
}
