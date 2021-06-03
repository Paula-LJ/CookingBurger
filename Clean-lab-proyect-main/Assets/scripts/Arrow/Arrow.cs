using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject arrowObject;
    public CameraRotate cameraRotate;
    public float timeAppeareArrow = 5.0f; 
    float RotationSpeed = 20.0f;
    // Start is called before the first frame update
    void Start()
    {
        arrowObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(cameraRotate.time); 
        if (cameraRotate.timeChange - timeAppeareArrow <= cameraRotate.time && cameraRotate.timeChange >= cameraRotate.time) 
        { 
            arrowObject.SetActive(true);
            arrowObject.transform.Rotate(Vector3.up * (RotationSpeed * Time.deltaTime)); 
        }
        else
            arrowObject.SetActive(false);


    }
}
