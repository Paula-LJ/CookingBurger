using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewPrefab : MonoBehaviour
{
    public GiveObject giveObject;

    private bool CreateOnePrefab = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("SpaceInstanceFood"))
        {
            giveObject.giveObjSpace = false;
            if (giveObject.pickedObject != null && giveObject.times >= 5.0f && CreateOnePrefab == true)
            {
                Instantiate(giveObject.pickedObject, giveObject.pickedObject.transform.position, giveObject.pickedObject.transform.rotation);
                CreateOnePrefab = false;
            }
            if (giveObject.pickedObject == null && giveObject.times >= giveObject.secondsGiveObject-1.0f && giveObject.times <= giveObject.secondsGiveObject)
                CreateOnePrefab = true;
        }
    }
}
