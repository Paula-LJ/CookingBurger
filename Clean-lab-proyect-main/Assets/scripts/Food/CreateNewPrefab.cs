using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPrefab : MonoBehaviour
{
    public GiveObject giveObject;
    public GameObject gameObject; 
    public bool spaceInstance = false;
    private Vector3 positionPrefab; 

        private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceInstanceFood"))
        {
            spaceInstance = true;
            //No se pueda dejar ni coger un objeto si esta con un objeto cogido y esta en la zona de coger
            if (giveObject.pickedObject != null)
                giveObject.timeStop = 0.0f; 
        }
        //cada vez que se coge un objeto, la variable time se inicializa, pero seguidamente augmenta. 
        //Solo entra una sola vez
        if (other.gameObject.CompareTag("Object") && spaceInstance == true && other.gameObject.name != "clean_dish")
        {
            giveObject.giveObjSpace = false;
            //Crear la instancia del objeto que colisiona
            if (giveObject.pickedObject == null)
                positionPrefab = other.transform.position; 
            if (giveObject.pickedObject != null && giveObject.times==0.0f) // 
            {
                GameObject go = Instantiate(other.gameObject, positionPrefab, other.transform.rotation);
                go.transform.parent = gameObject.transform;
                go.name = other.name; 
            }
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceInstanceFood"))
            spaceInstance = false;
    }
}
