using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float time = 0.0f;
    //Los segundos que rotatá el escenario
    private float timeCangePrivate = 5.0f; 
    public float timeChange;
    public Camera cam;
    public Camera cam1;
    
    private Vector3 NewPosition; // = new Vector3(49, 30, 72); 
    public Vector3 NewRotation; //= new Vector3(0, 180, 0); 
    private bool moveCamera = false;
    public Vector3 com_rot = new Vector3(0, 180, 0);
    public Vector3 com_rot2 = new Vector3(0, 0, 180);

	// Start is called before the first frame update
	private Vector3 rota = new Vector3  (90,0,0);
    void Start()
    {
        NewPosition = cam1.transform.position;
        NewRotation = cam1.transform.eulerAngles + rota ;
    }

    // Update is called once per frame
    void Update()
    {
        timeChange = timeCangePrivate; 
        time += Time.deltaTime;
        //Debug.Log(time);
        //Debug.Log(cam1.transform.eulerAngles);

        if (time >= timeCangePrivate && time <= timeCangePrivate + 0.5f && moveCamera == false)
        {
            moveCamera = true;
            cam.transform.position = NewPosition;
			if (cam1.CompareTag("Cam1")) {
				cam.transform.Rotate(NewRotation + com_rot+ com_rot2, Space.World);
				//cam.targetDisplay = 2;
			}

			else
				cam.transform.Rotate( NewRotation + com_rot2, Space.World);

        }
    }
}
