using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freidora : MonoBehaviour
{
    public AudioClip frieSound;

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
            if (other.name == "Fries Cut")
            {
                sound.PlayOneShot(frieSound, 0.2f); //Sonido freidora
            }
        }
    }
}
