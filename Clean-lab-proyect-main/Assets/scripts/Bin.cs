using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public AudioClip moneySound;
    public GiveObject giveObject;
    public float timeDestroy;

    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            sound.PlayOneShot(moneySound, 0.2f); //So paperera
            //Destrueix l'objecte
            giveObject.giveObj = false;
            Destroy(other.gameObject, timeDestroy);
			giveObject.pickedObject = null;
            giveObject.giveObj = false;
        }
    }
}
