using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GiveObject : MonoBehaviour
{
	public GameObject handPoint; //punto del player donde hacemos el trigger
	public float times = 0.0f; //tiempo coger
	public float secondsGiveObject;  //segundos de coger y dejar un objeto
	public GameObject pickedObject = null; //objeto que tiene el player
	private GameObject auxiliar = null; //objeto que tiene el player
	public float timeStop = 0.0f; //tiempo parar
	public bool isDestroy = false; // si tiene un objeto cogido y esta en la papelera
	public bool giveObj = false; //si tiene un objeto el player
	public bool changeIngredients = false; //si tiene un objeto el player
	public bool giveObjSpace = true;
	public CreateNewPrefab createNewPrefab;
	public GameObject[] prefabs;
	public ParticleSystem[] patricles;
	public GameObject SpaceRotate;
	//If is stop in area
	private List<Vector3> positions = new List<Vector3>();
	private int cont = 0;
	public float velocity = 0;

	//Sound
	public GameObject bubbles;
	public GameObject cortar;
	public GameObject sarten;
	public GameObject freidora;


	void Update()
	{
		if (giveObj == true) //si tiene obj el player
		{
			cont += 1;
			positions.Add(createNewPrefab.transform.position);

			if (cont != 1) // calcular velocidad
			{
				Vector3 vector1 = positions[cont - 1] - positions[cont - 2];
				velocity = vector1.magnitude;
				if (velocity < 0.2f) //no hay movimiento
					timeStop += Time.deltaTime;
				else //hay movimiento
					timeStop = 0.0f;

			}
			if (cont == 2) //restear lista
			{
				positions = new List<Vector3>();
				cont = 0;
			}

		}
		else
		{
			cont = 0;
			timeStop = 0.0f;
		}
		// dejar un objeto
		if (pickedObject != null && isDestroy == false && timeStop > secondsGiveObject && giveObj == true && giveObjSpace == true && changeIngredients == false)
		{
			// si el tiempo de sin movimiento es mayor a 2 y menor a 2.5 y es mayor el tiempo real del tiempo de estar parado para cogerlo y si no hay movimiento 
			pickedObject.GetComponent<Rigidbody>().useGravity = false;
			pickedObject.GetComponent<Rigidbody>().isKinematic = false;
			pickedObject.transform.parent = SpaceRotate.transform;

			giveObj = false;
			pickedObject = null;

		}
		if (pickedObject == null) // si no tiene nungun obj cogido que pueda coger un nuevo
			giveObj = false;


	}


	//Si el jugador esta 5 segundos encima del objeto con el tag Objects, se lo puede llevar
	private void OnTriggerStay(Collider other)
	{
		//poner cada objeto diferente en una altura diferente.
		if (other.gameObject.name.Contains("clean_dish")) //mirar si el objeto esta colisionando con el plato limpio
		{
			if (pickedObject)//miramos si tiene un objeto en la mano
			{
				if (pickedObject.gameObject.name.Contains("Bread_Top"))//si es asi, miramos si el objeto es algo cocinado
				{
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						auxiliar = Instantiate(pickedObject, handPoint.transform.position, Quaternion.identity);
						auxiliar.name = pickedObject.name;
						Destroy(pickedObject);// lo borramos
						pickedObject.gameObject.transform.SetParent(null);
						giveObj = false;
						pickedObject = null;

						auxiliar.gameObject.transform.SetParent(other.gameObject.transform); //y si  lo hacemos hijo del plato 
						auxiliar.gameObject.transform.position = other.gameObject.transform.position; //cambiamos la posicion a la del plato 
						Vector3 aux = auxiliar.gameObject.transform.position;
						aux.y += 10.0f; //mover sobre el eje y
						auxiliar.gameObject.transform.position = aux;
						auxiliar.GetComponent<BoxCollider>().enabled = false;
						auxiliar.GetComponent<BoxCollider>().isTrigger = false;
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}
			if (pickedObject)//miramos si tiene un objeto en la mano
			{
				if (pickedObject.gameObject.name.Contains("Burger_down"))//si es asi, miramos si el objeto es algo cocinado
				{
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						auxiliar = Instantiate(pickedObject, handPoint.transform.position, Quaternion.identity);
						auxiliar.name = pickedObject.name;
						Destroy(pickedObject); //lo borramos
						pickedObject.gameObject.transform.SetParent(null);
						giveObj = false;
						pickedObject = null;

						auxiliar.gameObject.transform.SetParent(other.gameObject.transform); //y si  lo hacemos hijo del plato 
						auxiliar.gameObject.transform.position = other.gameObject.transform.position; //cambiamos la posicion a la del plato 
						auxiliar.GetComponent<BoxCollider>().enabled = false;
						auxiliar.GetComponent<BoxCollider>().isTrigger = false;
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}
			if (pickedObject)//miramos si tiene un objeto en la mano
			{
				if (pickedObject.gameObject.name.Contains("Tomato_cut"))//si es asi, miramos si el objeto es algo cocinado
				{
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						auxiliar = Instantiate(pickedObject, handPoint.transform.position, Quaternion.identity);
						auxiliar.name = pickedObject.name;
						Destroy(pickedObject);// lo borramos
						pickedObject.gameObject.transform.SetParent(null);
						giveObj = false;
						pickedObject = null;

						auxiliar.gameObject.transform.SetParent(other.gameObject.transform); //y si  lo hacemos hijo del plato 
						auxiliar.gameObject.transform.position = other.gameObject.transform.position; //cambiamos la posicion a la del plato 
						Vector3 aux = auxiliar.gameObject.transform.position;
						aux.y += 1.0f; //mover sobre el eje y
						auxiliar.gameObject.transform.position = aux;
						auxiliar.GetComponent<BoxCollider>().enabled = false;
						auxiliar.GetComponent<BoxCollider>().isTrigger = false;
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}
			if (pickedObject)//miramos si tiene un objeto en la mano
			{
				if (pickedObject.gameObject.name.Contains("Salad_cut"))//si es asi, miramos si el objeto es algo cocinado
				{
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						auxiliar = Instantiate(pickedObject, handPoint.transform.position, Quaternion.identity);
						auxiliar.name = pickedObject.name;
						Destroy(pickedObject);// lo borramos
						pickedObject.gameObject.transform.SetParent(null);
						giveObj = false;
						pickedObject = null;

						auxiliar.gameObject.transform.SetParent(other.gameObject.transform); //y si  lo hacemos hijo del plato 
						auxiliar.gameObject.transform.position = other.gameObject.transform.position; //cambiamos la posicion a la del plato 
						Vector3 aux = auxiliar.gameObject.transform.position;
						aux.y += 8; //mover sobre el eje y
						auxiliar.gameObject.transform.position = aux;
						auxiliar.GetComponent<BoxCollider>().enabled = false;
						auxiliar.GetComponent<BoxCollider>().isTrigger = false;
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}
			if (pickedObject)//miramos si tiene un objeto en la mano
			{
				if (pickedObject.gameObject.name.Contains("Pickle_cut"))//si es asi, miramos si el objeto es algo cocinado
				{
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						auxiliar = Instantiate(pickedObject, handPoint.transform.position, Quaternion.identity);
						auxiliar.name = pickedObject.name;
						Destroy(pickedObject);// lo borramos
						pickedObject.gameObject.transform.SetParent(null);
						giveObj = false;
						pickedObject = null;

						auxiliar.gameObject.transform.SetParent(other.gameObject.transform); //y si  lo hacemos hijo del plato 
						auxiliar.gameObject.transform.position = other.gameObject.transform.position; //cambiamos la posicion a la del plato 
						Vector3 aux = auxiliar.gameObject.transform.position;
						aux.y += 3.0f; //mover sobre el eje y
						auxiliar.gameObject.transform.position = aux;
						auxiliar.GetComponent<BoxCollider>().enabled = false;
						auxiliar.GetComponent<BoxCollider>().isTrigger = false;
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}
			if (pickedObject)//miramos si tiene un objeto en la mano
			{
				if (pickedObject.gameObject.name.Contains("Onion_cut"))//si es asi, miramos si el objeto es algo cocinado
				{
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						auxiliar = Instantiate(pickedObject, handPoint.transform.position, Quaternion.identity);
						auxiliar.name = pickedObject.name;
						Destroy(pickedObject);// lo borramos
						pickedObject.gameObject.transform.SetParent(null);
						giveObj = false;
						pickedObject = null;

						auxiliar.gameObject.transform.SetParent(other.gameObject.transform); //y si  lo hacemos hijo del plato 
						auxiliar.gameObject.transform.position = other.gameObject.transform.position; //cambiamos la posicion a la del plato 
						Vector3 aux = auxiliar.gameObject.transform.position;
						aux.y += 4.0f; //mover sobre el eje y
						auxiliar.gameObject.transform.position = aux;
						auxiliar.GetComponent<BoxCollider>().enabled = false;
						auxiliar.GetComponent<BoxCollider>().isTrigger = false;
						changeIngredients = false;
						timeStop = 0.0f;
					}

				}
			}
			if (pickedObject)//miramos si tiene un objeto en la mano
			{
				if (pickedObject.gameObject.name.Contains("Cheese_cut"))//si es asi, miramos si el objeto es algo cocinado
				{
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						auxiliar = Instantiate(pickedObject, handPoint.transform.position, Quaternion.identity);
						auxiliar.name = pickedObject.name;
						Destroy(pickedObject);// lo borramos
						pickedObject.gameObject.transform.SetParent(null);
						giveObj = false;
						pickedObject = null;

						auxiliar.gameObject.transform.SetParent(other.gameObject.transform); //y si  lo hacemos hijo del plato 
						auxiliar.gameObject.transform.position = other.gameObject.transform.position; //cambiamos la posicion a la del plato 
						Vector3 aux = auxiliar.gameObject.transform.position;
						aux.y += 5.0f; //mover sobre el eje y
						auxiliar.gameObject.transform.position = aux;
						auxiliar.GetComponent<BoxCollider>().enabled = false;
						auxiliar.GetComponent<BoxCollider>().isTrigger = false;
						changeIngredients = false;
						timeStop = 0.0f;
					}

				}
			}
			if (pickedObject)//miramos si tiene un objeto en la mano
			{
				if (pickedObject.gameObject.name.Contains("Burger_Cooked"))//si es asi, miramos si el objeto es algo cocinado
				{
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						auxiliar = Instantiate(pickedObject, handPoint.transform.position, Quaternion.identity);
						auxiliar.name = pickedObject.name;
						Destroy(pickedObject);// lo borramos
						pickedObject.gameObject.transform.SetParent(null);
						giveObj = false;
						pickedObject = null;

						auxiliar.gameObject.transform.SetParent(other.gameObject.transform); //y si  lo hacemos hijo del plato 
						auxiliar.gameObject.transform.position = other.gameObject.transform.position; //cambiamos la posicion a la del plato 
						Vector3 aux = auxiliar.gameObject.transform.position;
						aux.y += 6.0f; //mover sobre el eje y
									   //aux.z -= 2.0f; //mover sobre el eje y
						auxiliar.gameObject.transform.position = aux;
						auxiliar.GetComponent<BoxCollider>().enabled = false;
						auxiliar.GetComponent<BoxCollider>().isTrigger = false;
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}

		}

		//cambio de assets
		if (other.gameObject.CompareTag("Bubbles"))
		{ //si colisionamos con la pica i con el plato sucio creamos la animacion de burbujas y destruimos el plato
			if (pickedObject != null)
			{
				if (pickedObject.name.Contains("Plate dirty")) //Si tenemos el plato sucio lo destruimos
				{
					patricles[0].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{

						Instantiate(bubbles);
						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[0], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[0].name;
						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}
		}
		if (other.gameObject.name.Contains("cuttingBoard"))
		{ //si colisionamos con madera de cortar
			if (pickedObject != null) //si tenemos un objeto en la mano
			{
				if (pickedObject.name == "Tomato") //Si tenemos el tomate
				{
					patricles[1].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						Instantiate(cortar);
						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[1], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[1].name;
						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						changeIngredients = false;
						timeStop = 0.0f;
					}

				}
				if (pickedObject.name == "Salad") //Si tenemos la lechuga
				{
					patricles[2].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						Instantiate(cortar);
						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[2], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[2].name;
						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						changeIngredients = false;
						timeStop = 0.0f;
					}


				}
				if (pickedObject.name == "Onion") //Si tenemos la cebolla
				{
					patricles[3].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						Instantiate(cortar);

						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[3], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[3].name;
						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						changeIngredients = false;
						timeStop = 0.0f;
					}

				}
				if (pickedObject.name == "Cheese") //Si tenemos el queso
				{
					patricles[4].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						Instantiate(cortar);

						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[4], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[4].name;
						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						changeIngredients = false;
						timeStop = 0.0f;
					}

				}
				if (pickedObject.name == "Cucumber") //Si tenemos el pepino
				{
					patricles[2].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						Instantiate(cortar);

						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[5], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[5].name;
						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						changeIngredients = false;
						timeStop = 0.0f;
					}

				}
				if (pickedObject.name == "Potato uncooked") //Si tenemos la patata 
				{

					patricles[4].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						Instantiate(cortar);

						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[6], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[6].name;

						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}
		}
		if (other.gameObject.name == "PW_stove")
		{
			if (pickedObject != null)
			{
				if (pickedObject.name == "Burger UnCooked") //Si tenemos la hamburgesa cruda
				{
					patricles[5].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						Instantiate(sarten);
						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[7], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[7].name;
						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						Vector3 aux = pickedObject.gameObject.transform.position;
						aux.y += 10.0f; //mover sobre el eje y
						pickedObject.gameObject.transform.position = aux;
						changeIngredients = false;
						timeStop = 0.0f;
					}
				}
			}
		}
		if (other.gameObject.name == "frites Machine")
		{
			if (pickedObject != null)
			{
				if (pickedObject.name == "Fries Cut") //Si tenemos las patatas cortadas
				{

					patricles[6].Play();
					changeIngredients = true;
					if (timeStop >= secondsGiveObject && timeStop <= secondsGiveObject + 0.5f && changeIngredients == true)
					{
						Instantiate(freidora);

						Destroy(pickedObject);
						pickedObject = null;
						giveObj = true;

						pickedObject = Instantiate(prefabs[8], handPoint.transform.position, Quaternion.identity);
						pickedObject.name = prefabs[8].name;
						pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);
						changeIngredients = false;
						timeStop = 0.0f;
					}

				}
			}
		}
		if (other.gameObject.CompareTag("Object"))
		{
			if (other.gameObject.name == "clean_dish" && pickedObject != null)
				times = 0;
			else
				times += Time.deltaTime;

			if (times >= secondsGiveObject && times <= secondsGiveObject + 0.5f && pickedObject == null && giveObj == false && changeIngredients == false) //coger objeto 
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().isKinematic = true;
				giveObj = true;
				other.transform.position = handPoint.transform.position;
				other.gameObject.transform.SetParent(handPoint.gameObject.transform);
				pickedObject = other.gameObject;
				times = 0.0f;
			}
		}



	}
	//si no esta activado el trigger que la variable tiempo se inicialice a 0. Y la variable de tirar un objecto sea False para poder dejar un objeto nuevo que cogamos 
	private void OnTriggerExit(Collider other)
	{
		times = 0.0f;
		isDestroy = false;
		changeIngredients = false;
		if (other.gameObject.CompareTag("SpaceInstanceFood"))
		{
			giveObjSpace = true;
		}
	}

}