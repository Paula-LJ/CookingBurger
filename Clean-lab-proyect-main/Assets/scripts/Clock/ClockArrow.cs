using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockArrow : MonoBehaviour
{
    public GameObject arrowClock;
    private float Speed=17.0f;
    public rotateScene rotateS; 

    // Update is called once per frame
    void Update()
    {
        if(rotateS.timeChange!=0.0f)
            Speed =  (arrowClock.transform.position.z * 2 * Mathf.PI ) /(rotateS.timeChange * 2);
        arrowClock.transform.RotateAround(transform.position, -Vector3.down, Speed * Time.deltaTime); 
    }
}
