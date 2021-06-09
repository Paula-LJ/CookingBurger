using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public AudioClip moneySound;
    public GiveObject giveObject;

    private AudioSource sound;
    private GameObject childother;

    public Spawn spawn;
    public bool OneRandom = false;
    public int numClient = 0;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (OneRandom == true) { //borrar cliente y desaparecer speak/ entre una sola vez
            Destroy(spawn.clients[numClient].prefabClient);
            spawn.clients[numClient].prefabSpeak.SetActive(false);
            OneRandom = false;

        }

    }

   
    private void OnTriggerEnter(Collider other) //other es la otra cosa con la que colisiona
    {
        if (other.CompareTag("Object"))
        {
            childother = other.transform.GetChild(0).gameObject;
			

            if (childother.CompareTag("Burger")) //borrar cuando se acabe el juego 
            {
                sound.PlayOneShot(moneySound, 0.2f);
                OneRandom = true;
            }

            //FALTARIA COMPARA SI ÉS O NO L'HAMBURGUESA DEMANADA 
            for (int j = 0; j < 3; j++)
            {
                if (gameObject.name == "Clients " + j.ToString())
                {

                    for (int i = 0; i < spawn.clients[j].IngredientList.Count; i++) //Comparar lo que lleva encima con lo que piede el cliente
                    {
                        if (spawn.clients[j].IngredientList[i].name == other.name)
                        {
                            Destroy(spawn.clients[j].IngredientList[i]); 
                            spawn.clients[j].IngredientList.Remove(spawn.clients[j].IngredientList[i]); //borrar prefab y de la lista que coincide con lo entregado
                        }
                    }
                    if (spawn.clients[j].IngredientList.Count == 0)  // cuando se ha entregado todas las prefabs que se pedia en la lista de ingredientes
                    {
                        OneRandom = true;
                        numClient = j; // id de cliente que se entrega

                    }

                }
            }
			//Destrueix l'objecte entregat (sigui o no el que ha demanat)
			giveObject.giveObj = false;
            Destroy(other.gameObject);
            giveObject.pickedObject = null;
        }
    }
}
