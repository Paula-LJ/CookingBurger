using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject prefab;

    private Vector3 prefabPosition;
    private float time = 0.0f;
    private float timeNewCustomer = 5.0f;
    private float timeStop = 20.0f;
    private int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        //prefabPosition = new Vector3(prefab.transform.position.x-15f, prefab.transform.position.y, prefab.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        //Debug.Log(time);
       
        //Crea clients cada x temps
        if (time % timeNewCustomer >= 0.000299 && time % timeNewCustomer <= 0.01 && time < timeStop) //El temps per crear un nou client sigui múltiple de 5 (timeNewCustomer)
        {
            //Debug.Log("Hola");
            prefabPosition = new Vector3(prefab.transform.position.x - i*15f, prefab.transform.position.y, prefab.transform.position.z);
            Instantiate(prefab, prefabPosition, prefab.transform.rotation);
            i++;
        }

        //Crea només un client
        //if (time >= timeNewCustomer && time <= timeNewCustomer + 0.004f)
        //{
        //    Instantiate(prefab, prefabPosition, prefab.transform.rotation);
        //}

    }
}
