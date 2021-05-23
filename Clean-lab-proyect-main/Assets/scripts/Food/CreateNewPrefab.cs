using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPrefab : MonoBehaviour
{
    public GiveObject giveObject;
    public bool spaceInstance = false; 

        private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceInstanceFood"))
        {
            spaceInstance = true;
            //No se pueda dejar ni coger un objeto si esta con un objeto cogido y esta en la zona de coger
            if (giveObject.pickedObject != null) {
                giveObject.timeStop = 0.0f; 
            }
        }
        //cada vez que se coge un objeto, la variable time se inicializa, pero seguidamente augmenta. 
        //Solo entra una sola vez
        if (other.gameObject.CompareTag("Object") && spaceInstance == true)
        {
            giveObject.giveObjSpace = false;
            //Crear la instancia del objeto que colisiona
            if (giveObject.pickedObject != null && giveObject.times==0.0f) // 
            {
                Instantiate(other.gameObject, other.transform.position, other.transform.rotation);
            }
            
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceInstanceFood"))
        {
            spaceInstance = false;
        }
    }
}
