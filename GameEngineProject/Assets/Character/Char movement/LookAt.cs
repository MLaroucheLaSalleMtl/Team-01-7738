﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtOld : MonoBehaviour
{
    [SerializeField] private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(target);
    }
}
