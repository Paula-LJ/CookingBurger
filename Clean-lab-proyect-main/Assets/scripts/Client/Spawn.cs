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
    public float cantidadClientes = 3.0f;
    private float valueSum = 0.0025f; 
    public int i = 1;
    
    public rotateScene rotateS;
    
    private bool OneRandom = true;
    private float randomNum = 0.0f; 
    private float time = 0.0f;

    //Order Burger
    public GameObject[] IngredientUncooked;
    public GameObject[] IngredientAlways;
    public Customer customer; 
    private int ranPrefab;
    [System.Serializable]
    public class Client
    {
        public GameObject prefabClient;
        public GameObject prefabSpeak;
        public List<GameObject> IngredientList; 
        public int numIngredients = 4; 
    }
    public Client[] clients; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Crea los tres primeros clientes
    void Update()
    {
        if(i !=4) //1 a 4 
            cont += valueSum;
        //Crea clients cada x temps
        if (cont > 1*i && cont < (1*i + valueSum) && cont < (cantidadClientes+1)) //Si esta entre este rango, se cree cada cliente (los tres primeros)
        {
            if (rotateS.time > rotateS.timeChange) //rotando escenario
            {
                prefabPosition = new Vector3(prefab.transform.position.x + 20 + i * 30f, prefab.transform.position.y, prefab.transform.position.z);
                SepakPosition = new Vector3(speakPrefab.transform.position.x + 20 + i * 30f, speakPrefab.transform.position.y, speakPrefab.transform.position.z);
            }
            else //sin rotar escenario
            {
                prefabPosition = new Vector3(prefab.transform.position.x - 20 - i * 30f, prefab.transform.position.y, prefab.transform.position.z);
                SepakPosition = new Vector3(speakPrefab.transform.position.x - 20 - i * 30f, speakPrefab.transform.position.y, speakPrefab.transform.position.z);
            }
            clients[i - 1].prefabClient = Instantiate(prefab, prefabPosition, prefab.transform.rotation);
            clients[i - 1].prefabClient.transform.parent = FolderClient.transform;
            clients[i - 1].prefabClient.name = prefab.name + " "+ (i - 1).ToString();
            clients[i - 1].prefabSpeak = Instantiate(speakPrefab, SepakPosition, speakPrefab.transform.rotation);
            clients[i - 1].prefabSpeak.transform.parent = FolderClient.transform;
            clients[i - 1].prefabSpeak.name = speakPrefab.name + " " + (i-1).ToString();

            OrderBurger(i); 
            i++;
        }
        

        if (i == 4 && (rotateS.time < (rotateS.timeChange *2 -60))) // se creen los nuevos clientes que se ha servido correctamente la comida / este en el tiempo de juego menos un minuto
        {
            for (int j = 0; j < 3; j++)
            {
                if (clients[j].prefabClient == null)
                {
                    if (OneRandom == true)
                    {
                        randomNum = Random.Range(0, 10);
                        OneRandom = false; 
                    }
                    time += Time.deltaTime;

					if (time > randomNum && time < (randomNum+0.5))
					{
						int i = j + 1;
						if (rotateS.time > rotateS.timeChange) //rotando escenario
						{
							prefabPosition = new Vector3(prefab.transform.position.x + 20 + i * 30f, prefab.transform.position.y,prefab.transform.position.z);
						}
						else //sin rotar escenario
						{
							prefabPosition = new Vector3(prefab.transform.position.x - 20 - i * 30f, prefab.transform.position.y, prefab.transform.position.z);
						}
                        clients[j].prefabClient = Instantiate(prefab, prefabPosition, prefab.transform.rotation);
                        clients[j].prefabClient.transform.parent = FolderClient.transform;
                        clients[j].prefabClient.name = prefab.name + " " + (i - 1).ToString();

                        clients[j].prefabSpeak.SetActive(true);

                        OneRandom = true;
                        customer.SoundOne = true; 
                        time = 0.0f; 
                        //Generar la nueva lista de alimentos 
                        OrderBurger(j+1);
                    }

                }
            }
        }
        
    }

    public void OrderBurger(int i)
    {
		for (int y = 0; y < IngredientAlways.Length; y++)//ingredientes que estan siempre
        {
            clients[i - 1].IngredientList.Add(Instantiate(IngredientAlways[y], clients[i - 1].prefabSpeak.transform.position + new Vector3(9-(3f*y) , 6, 0), IngredientAlways[y].transform.rotation)); 
            clients[i - 1].IngredientList[y].transform.parent = FolderClient.transform;
            clients[i - 1].IngredientList[y].name = IngredientAlways[y].name;
        }

		ranPrefab = Random.Range(0, IngredientUncooked.Length);
        clients[i - 1].IngredientList.Add(Instantiate(IngredientUncooked[ranPrefab], clients[i - 1].prefabSpeak.transform.position + new Vector3(9 - (3.5f * IngredientAlways.Length), 6, 0) , IngredientUncooked[ranPrefab].transform.rotation)); //ingredientes random
        clients[i - 1].IngredientList[IngredientAlways.Length].transform.parent = FolderClient.transform;
        clients[i - 1].IngredientList[IngredientAlways.Length].name = IngredientUncooked[ranPrefab].name;

    }
}
