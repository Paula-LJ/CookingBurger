using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateScene : MonoBehaviour
{
    public GameObject scene;
    //public GiveObject giveobject;
    private float timeChange;
    private float time;
    private float timeCangePrivate = 5.0f;
    private bool one = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

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
