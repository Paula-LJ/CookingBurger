using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject prefab;
    public GameObject speakPrefab;
    public GameObject FolderClient;
    //public GiveObject giveObject; 

    private Vector3 prefabPosition;
    private Vector3 SepakPosition;
    private float cont = 0.0f;
    private float cantidadClientes = 3.0f;
    private float valueSum = 0.0025f; 
    private int i = 1;
    //
    public rotateScene rotateS; 
    //Order Burger
    public GameObject[] IngredientUncooked;
    public GameObject[] IngredientAlways;
    private int ranPrefab;
    [System.Serializable]
    public class Client
    {
        public GameObject prefabClient;
        public GameObject[] ingredients;
        public GameObject prefabSpeak;
    }
    public Client[] clients; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        cont += valueSum;
        //Crea clients cada x temps
        if (cont > 1*i && cont < (1*i + valueSum) && cont < (cantidadClientes+1)) //El temps per crear un nou client sigui múltiple de 5 (timeNewCustomer)
        {
            if (rotateS.time > rotateS.timeChange) //rotando
            {
                prefabPosition = new Vector3(prefab.transform.position.x + 25 + i * 25f, prefab.transform.position.y, prefab.transform.position.z);
                SepakPosition = new Vector3(speakPrefab.transform.position.x + 25 + i * 25f, speakPrefab.transform.position.y, speakPrefab.transform.position.z);
            }
            else //sin rotar
            {
                prefabPosition = new Vector3(prefab.transform.position.x - 25 - i * 25f, prefab.transform.position.y, prefab.transform.position.z);
                SepakPosition = new Vector3(speakPrefab.transform.position.x -25 - i * 25f, speakPrefab.transform.position.y, speakPrefab.transform.position.z);
            }
            clients[i - 1].prefabClient = Instantiate(prefab, prefabPosition, prefab.transform.rotation);
            clients[i - 1].prefabSpeak = Instantiate(speakPrefab, SepakPosition, speakPrefab.transform.rotation);
            clients[i - 1].prefabClient.transform.parent = FolderClient.transform;
            clients[i - 1].prefabSpeak.transform.parent = FolderClient.transform;
            OrderBurger(i); 
            i++;
        }

        
    }

    public void OrderBurger(int i)
    {
		for (int y = 0; y < IngredientAlways.Length; y++)
		{
			if (y == 1)
                clients[i - 1].ingredients[y] = Instantiate(IngredientAlways[y], clients[i - 1].prefabSpeak.transform.position + new Vector3(3.5f, 6, 0), IngredientAlways[y].transform.rotation); //hamburgesa
			else
                clients[i - 1].ingredients[y] = Instantiate(IngredientAlways[y], clients[i - 1].prefabSpeak.transform.position + new Vector3(5-(3f*y) , 6, 0), IngredientAlways[y].transform.rotation); //ingredientes que estan siempre
            clients[i - 1].ingredients[y].transform.parent = FolderClient.transform;
            clients[i - 1].ingredients[y].name = IngredientAlways[y].name; 


        }

		ranPrefab = Random.Range(0, IngredientUncooked.Length);
        clients[i - 1].ingredients[3] = Instantiate(IngredientUncooked[ranPrefab], clients[i - 1].prefabSpeak.transform.position + new Vector3(-4, 6, 0) , IngredientUncooked[ranPrefab].transform.rotation); //ingredientes random
        clients[i - 1].ingredients[3].transform.parent = FolderClient.transform;
        clients[i - 1].ingredients[3].name = IngredientUncooked[ranPrefab].name;

    }
}
