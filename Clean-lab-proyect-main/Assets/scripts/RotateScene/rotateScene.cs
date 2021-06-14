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

   
    void Update()
    {
        timeChange = timeCangePrivate;
        time += Time.deltaTime;
        
        if (time >= timeCangePrivate && time <= timeCangePrivate + 0.5f && one == true) //rotacion de la escena a los 2 min
        {
            one = false;
            scene.transform.Rotate(new Vector3(0, 180, 0), Space.World);

        }
    }
}
