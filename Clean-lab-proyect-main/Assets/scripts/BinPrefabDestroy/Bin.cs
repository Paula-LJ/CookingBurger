using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public AudioClip binSound;
    public GiveObject giveObject;
    public Spawn spawn; 
    public GameObject dish_dirty;
    private GameObject aux; 
    public rotateScene rotateS;

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
            sound.PlayOneShot(binSound, 0.2f); //So paperera
            //Destrueix l'objecte
            giveObject.giveObj = false;
            Destroy(other.gameObject, timeDestroy);
            giveObject.pickedObject = null;
            giveObject.giveObj = false;
            if (other.gameObject.name.Contains("clean_dish") || other.gameObject.name.Contains("Plate dirty"))
            {
                if (rotateS.time < rotateS.timeChange)
                    aux = Instantiate(dish_dirty, new Vector3(95, 10, 83), Quaternion.identity);
                else
                    aux = Instantiate(dish_dirty, new Vector3(8, 10, 17), Quaternion.identity);
                aux.transform.parent = spawn.FolderClient.transform;
                aux.name = dish_dirty.name;
            }
        }
    }
}
