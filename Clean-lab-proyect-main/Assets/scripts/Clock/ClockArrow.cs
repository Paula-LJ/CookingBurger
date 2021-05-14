﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockArrow : MonoBehaviour
{
    public GameObject arrowClock;
    //public GameObject Clock;
    private float Speed=17.0f;
    public CameraRotate cameraRotate; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraRotate.timeChange!=0.0f)
            Speed =  (arrowClock.transform.position.z * 2 * Mathf.PI ) /(cameraRotate.timeChange * 2);
        arrowClock.transform.RotateAround(transform.position, -Vector3.down, Speed * Time.deltaTime); 
    }
}