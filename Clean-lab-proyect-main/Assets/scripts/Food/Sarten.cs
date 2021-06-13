using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sarten : MonoBehaviour
{
    public AudioClip panSound;

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
            if (other.name == "Burger UnCooked")
            {
                sound.PlayOneShot(panSound, 0.2f); //Sonido sartén
            }
        }
    }
}
