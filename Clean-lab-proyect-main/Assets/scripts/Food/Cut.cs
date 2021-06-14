using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cut : MonoBehaviour
{
    public AudioClip cutSound;
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
            if (other.name == "Potato uncooked")
            {
                sound.PlayOneShot(cutSound, 0.2f); //Sonido tabla
            }
            if (other.name == "Tomato")
            {
                sound.PlayOneShot(cutSound, 0.2f); //Sonido tabla
            }
            if (other.name == "Salad")
            {
                sound.PlayOneShot(cutSound, 0.2f); //Sonido tabla
            }
            if (other.name == "Onion")
            {
                sound.PlayOneShot(cutSound, 0.2f); //Sonido tabla
            }
            if (other.name == "Cheese")
            {
                sound.PlayOneShot(cutSound, 0.2f); //Sonido tabla
            }
            if (other.name == "Cucumber")
            {
                sound.PlayOneShot(cutSound, 0.2f); //Sonido tabla
            }
        }
    }
}
