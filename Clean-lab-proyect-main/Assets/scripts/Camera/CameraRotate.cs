using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float time = 0.0f;
    public Camera cam; 
    Vector3 pos3 = new Vector3(49, 30, 72); 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Debug.Log(time);
        if (time >= 5.0f && time <= 5.5f)
        {
            cam.transform.position = pos3; 
        }
    }
}
