using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrowObject;
    public rotateScene rotateS; 
    public float timeAppeareArrow = 5.0f; 
    float RotationSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        arrowObject.SetActive(false);
    }

    void Update()
    {
        if (rotateS.timeChange - timeAppeareArrow <= rotateS.time && rotateS.timeChange >= rotateS.time) 
        { 
            arrowObject.SetActive(true);
            arrowObject.transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime)); 
        }
        else
            arrowObject.SetActive(false);


    }
}
