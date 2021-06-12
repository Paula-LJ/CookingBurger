using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public AudioClip waterSound;

    private AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Object"))
        {
            if (other.name.Contains( "Plate dirty"))
            {
                sound.PlayOneShot(waterSound, 0.2f); //Sonido grifo
            }
        }
    }
}