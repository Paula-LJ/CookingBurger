using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    float time = 0.0f;
    float timeChange = 5.0f;
    public Camera cam;
    public Camera cam1;
    private Vector3 NewPosition; // = new Vector3(49, 30, 72); 
    private Vector3 NewRotation; //= new Vector3(0, 180, 0); 
    // Start is called before the first frame update
    private Vector3 rota = new Vector3  (90,0,0);
    void Start()
    {
        NewPosition = cam1.transform.position;
        NewRotation = cam1.transform.eulerAngles - rota;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
        Debug.Log(cam1.transform.eulerAngles);

        if (time >= timeChange && time <= timeChange+0.1f)
        {
            cam.transform.position = NewPosition;
           // if (cam.CompareTag("MainCamera"))
                cam.transform.Rotate( NewRotation, Space.World);

        }
    }
}
