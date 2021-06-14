using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScene : MonoBehaviour
{
    public GameObject scene;

    public float timeChange;
    public float time;
    private float timeCangePrivate = 120.0f; //2 min
    private bool one = true;
 
    // Update is called once per frame
    void Update()
    {
        timeChange = timeCangePrivate;
        time += Time.deltaTime;
        
        if (time >= timeCangePrivate && time <= timeCangePrivate + 0.5f && one == true)
        {
            one = false;
            scene.transform.Rotate(new Vector3(0, 180, 0), Space.World);
        }
    }
}
