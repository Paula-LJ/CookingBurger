using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPrefab : MonoBehaviour
{
    //public GameObject Prefab;
    //public GameObject SapcePrefab;
    public GiveObject giveObject;
    private bool CreateOnePrefab = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (giveObject.pickedObject == null)
            CreateOnePrefab = true;

        //if (Input.GetKeyDown(KeyCode.Space))    
        //     Instantiate(Prefab, SapcePrefab.transform.position, Prefab.transform.rotation); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceInstanceFood"))
        {
            if (giveObject.pickedObject != null && giveObject.times >= 5.0f && CreateOnePrefab == true)
            {
                Instantiate(giveObject.pickedObject, giveObject.pickedObject.transform.position, giveObject.pickedObject.transform.rotation);
                CreateOnePrefab = false;
            }
            
        }
    }
}
