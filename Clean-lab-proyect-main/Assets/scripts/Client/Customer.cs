using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public GameObject moneySound;
    public GiveObject giveObject;
    public GameObject dish_dirty;
    private GameObject aux; 

    public Spawn spawn;
    public bool OneRandom = false;
    public int numClient = 0;
    private int  contIngredients =0;
    public rotateScene rotateS;
    private bool passOne = true; 
    private bool passFunction = false;
    public int customerOut;
    public bool SoundOne = true; 

    void Update()
    {
        if (spawn.clients[numClient].IngredientList.Count == 0 && rotateS.time >60 && SoundOne==true) 
        {
            Instantiate(moneySound);
            SoundOne = false; 
        }
        if (OneRandom == true) { //borrar cliente y desaparecer speak/ entre una sola vez
            
            Destroy(spawn.clients[numClient].prefabClient);
            customerOut += 1; // Para contar los clientes servidos
            spawn.clients[numClient].prefabSpeak.SetActive(false);
            OneRandom = false;
            
        }
    }


    private void OnTriggerEnter(Collider other) //other es la otra cosa con la que colisiona
    {
        passFunction = false; 
        if (other.CompareTag("Object"))
        {
            for (int j = 0; j < 3; j++)
            {
                passOne = true; 
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
                            if (contIngredients == 4)
                            {
                                for (int m = 0; m < 6; m++)
                                {
                                    if (m < 3)
                                    {
                                        Destroy(spawn.clients[j].IngredientList[0]);
                                        spawn.clients[j].IngredientList.Remove(spawn.clients[j].IngredientList[0]); //borrar prefab y de la lista que coincide con lo entregado}
                                    }
                                    if (m > 4)
                                    {
                                        Destroy(spawn.clients[j].IngredientList[spawn.clients[j].IngredientList.Count - 1]);
                                        spawn.clients[j].IngredientList.Remove(spawn.clients[j].IngredientList[spawn.clients[j].IngredientList.Count - 1]); //borrar prefab y de la lista que coincide con lo entregado}
                                    }
                                }
                                passOne = false;

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
                        
                    }

                    }
                if (passOne == false)
                {

                    Destroy(other.gameObject);
                    giveObject.pickedObject = null;
                    giveObject.giveObj = false;

                    if (rotateS.time < rotateS.timeChange)
                        aux = Instantiate(dish_dirty, new Vector3(95, 10, 83), Quaternion.identity);
                    else
                        aux = Instantiate(dish_dirty, new Vector3(8, 10, 17), Quaternion.identity);
                    aux.transform.parent = spawn.FolderClient.transform;
                    aux.name = dish_dirty.name;
                    passFunction = true; 

                }
            }
            //Destrueix l'objecte entregat (sigui o no el que ha demanat)
            if (other.gameObject && other.gameObject.transform.childCount != 0)
            {
                Destroy(other.gameObject);
                giveObject.pickedObject = null;
                giveObject.giveObj = false;

            }

			if (other.gameObject.name == "clean_dish" && other.gameObject.transform.childCount != 0 && passFunction != true)
			{
				//si se entrega correcto devolvemos un plato sucio
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
