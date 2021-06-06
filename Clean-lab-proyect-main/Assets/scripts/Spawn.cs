using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject prefab;
    public GameObject FolderClient;

    private Vector3 prefabPosition;
    private float time = 0.0f;
    private float timeNewCustomer = 5.0f;
    private float timeStop = 20.0f;
    private int i = 1;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
       
        //Crea clients cada x temps
        if (time % timeNewCustomer >= 0.000299 && time % timeNewCustomer <= 0.01 && time < timeStop) //El temps per crear un nou client sigui múltiple de 5 (timeNewCustomer)
        {
            prefabPosition = new Vector3(prefab.transform.position.x - i*15f, prefab.transform.position.y, prefab.transform.position.z);
            GameObject NewClient = Instantiate(prefab, prefabPosition, prefab.transform.rotation);
            NewClient.transform.parent = FolderClient.transform; 
            i++;
        }

        
    }
}
