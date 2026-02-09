using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DibujaLineaApuntandoAObjetivo : MonoBehaviour
{
    public Transform objetivo;


    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if(objetivo == null)
            return;
        Vector2 direction = (objetivo.position - transform.position).normalized;
        Vector3 endpoint = transform.position + (Vector3)direction;
        Gizmos.DrawLine(transform.position, endpoint);
    }
}
