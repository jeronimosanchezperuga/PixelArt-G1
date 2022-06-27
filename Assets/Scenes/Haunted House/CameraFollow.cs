﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    float offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position.x - target.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x + offset,transform.position.y,transform.position.z);
    }
}
