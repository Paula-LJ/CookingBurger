using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public AudioClip moneySound;
    public GiveObject giveObject;

    private AudioSource sound;
    private GameObject childother;

    //&& giveObject.pickedObject!=null

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) //other es la otra cosa con la que colisiona
    {
        if (other.CompareTag("Object"))
        {
            childother = other.transform.GetChild(0).gameObject;
            
            if (childother.CompareTag("Burger"))
            {
                sound.PlayOneShot(moneySound, 0.2f);
            }

            //Faltaria comparar si és o no l'hamburguesa demanada
            giveObject.giveObj = false;
            Destroy(other.gameObject);
            giveObject.pickedObject = null;

        }
    }
}
