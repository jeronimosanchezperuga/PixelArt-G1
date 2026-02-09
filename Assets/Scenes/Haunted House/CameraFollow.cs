using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    bool seguimientoVertical;
    [SerializeField]
    float ajusteAltura;
    [SerializeField]
    Transform limiteIzquierdo;
    [SerializeField]
    Transform limiteDerecho;
    [SerializeField]
    Transform limiteSuperior;
    [SerializeField]
    Transform limiteInferior;

    float leftLimit;
    float rightLimit;
    float topLimit;
    float bottomLimit;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        leftLimit = limiteIzquierdo.position.x;
        rightLimit = limiteDerecho.position.x;        
        topLimit = limiteSuperior.position.y;
        bottomLimit = limiteInferior.position.y;       
    }

    // Update is called once per frame
    void Update()
    {
        if (!target)
            return;
        if (!limiteSuperior || !seguimientoVertical)
        {
            transform.position = new Vector3(Mathf.Clamp(target.position.x, leftLimit, rightLimit), transform.position.y, transform.position.z);
            return;
        }
        transform.position = new Vector3(Mathf.Clamp(target.position.x, leftLimit, rightLimit), Mathf.Clamp(target.position.y + ajusteAltura, bottomLimit, topLimit), transform.position.z);



    }
}
