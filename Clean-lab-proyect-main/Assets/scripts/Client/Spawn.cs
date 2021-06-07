using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject prefab;
    public GameObject speakPrefab;
    public GameObject FolderClient;

    private Vector3 prefabPosition;
    private Vector3 SepakPosition;
    private float cont = 0.0f;
    private float cantidadClientes = 3.0f;
    private float valueSum = 0.0025f; 
    private int i = 1;

    //Order Burger
    public GameObject[] IngredientUncooked;
    public GameObject[] IngredientAlways;
    GameObject NewSpeak;
    GameObject NewI; 
    private int ranNumOfPrefabs;
    private int ranPrefab;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cont += valueSum;
        //Crea clients cada x temps
        if (cont > 1*i && cont < (1*i + valueSum) && cont < (cantidadClientes+1)) //El temps per crear un nou client sigui m�ltiple de 5 (timeNewCustomer)
        {
            prefabPosition = new Vector3(prefab.transform.position.x+25 - i*25f, prefab.transform.position.y, prefab.transform.position.z);
            SepakPosition = new Vector3(speakPrefab.transform.position.x+25 - i*25f, speakPrefab.transform.position.y, speakPrefab.transform.position.z);
            GameObject NewClient = Instantiate(prefab, prefabPosition, prefab.transform.rotation);
            NewSpeak= Instantiate(speakPrefab, SepakPosition, speakPrefab.transform.rotation);
            NewClient.transform.parent = FolderClient.transform;
            NewSpeak.transform.parent = FolderClient.transform;
            OrderBurger(); 
            i++;
        }

        
    }

    public void OrderBurger()
    {
		for (int y = 0; y < IngredientAlways.Length; y++)
		{
			if (y == 1)
				NewI = Instantiate(IngredientAlways[y], NewSpeak.transform.position + new Vector3(3.5f, 6, 0), IngredientAlways[y].transform.rotation); //hamburgesa
			else
				NewI = Instantiate(IngredientAlways[y], NewSpeak.transform.position + new Vector3(5-(3f*y) , 6, 0), IngredientAlways[y].transform.rotation); //ingredientes que estan siempre
			NewI.transform.parent = FolderClient.transform; 

		}

		ranPrefab = Random.Range(0, IngredientUncooked.Length);
        NewI = Instantiate(IngredientUncooked[ranPrefab], NewSpeak.transform.position + new Vector3(-4, 6, 0) , IngredientUncooked[ranPrefab].transform.rotation); //ingredientes random
        NewI.transform.parent = FolderClient.transform;
    }
}