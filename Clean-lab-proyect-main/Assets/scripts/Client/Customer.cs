using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public AudioClip moneySound;
    public GiveObject giveObject;
    public GameObject dish_dirty;

    private AudioSource sound;
    private GameObject childother;

    public Spawn spawn;
    public bool OneRandom = false;
    public int numClient = 0;
    private int  contIngredients =0; 
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

            //FALTARIA COMPARA SI �S O NO L'HAMBURGUESA DEMANADA 
            for (int j = 0; j < 3; j++)
            {
                contIngredients = 0;
                if (gameObject.name == "Clients " + j.ToString())
                {

                    for (int i = 0; i < spawn.clients[j].IngredientList.Count; i++) //Comparar lo que lleva encima con lo que piede el cliente
                    {
                        if (other.gameObject.name == "clean_dish")
                        {
                            for (int k = 0; k < other.gameObject.transform.childCount; k++)
                            {
                                if (spawn.clients[j].IngredientList[i].name == other.gameObject.transform.GetChild(k).name)
                                    contIngredients += 1;
                            }
                            if(contIngredients== 4)
                            {
                                for (int m = 0; m < 6; m++)
                                {
                                    if (m <3)
                                    {
                                        Destroy(spawn.clients[j].IngredientList[0]);
                                        spawn.clients[j].IngredientList.Remove(spawn.clients[j].IngredientList[0]); //borrar prefab y de la lista que coincide con lo entregado}
                                    }
                                    if (m > 4)
                                    {
                                        Destroy(spawn.clients[j].IngredientList[2]);
                                        spawn.clients[j].IngredientList.Remove(spawn.clients[j].IngredientList[2]); //borrar prefab y de la lista que coincide con lo entregado}
                                    }
                                }
                                //si se entrega correcto devolvemos un plato sucio
                                dish_dirty = Instantiate(dish_dirty, new Vector3(92, 10, 83), Quaternion.identity);
                                dish_dirty.name = dish_dirty.name;

                            }

                        }
                        if (other.gameObject.name == "Fries Cooked" || other.gameObject.name == "cupRecto")
                        {
                            if (spawn.clients[j].IngredientList[i].name == other.gameObject.name)
                            {
                                Destroy(spawn.clients[j].IngredientList[i]);
                                spawn.clients[j].IngredientList.Remove(spawn.clients[j].IngredientList[i]); //borrar prefab y de la lista que coincide con lo entregado
                            }
                        }

                    }
                    if (spawn.clients[j].IngredientList.Count == 0)  // cuando se ha entregado todas las prefabs que se pedia en la lista de ingredientes
                    {
                        OneRandom = true;
                        numClient = j; // id de cliente que se entrega
                        sound.PlayOneShot(moneySound, 0.2f);

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
