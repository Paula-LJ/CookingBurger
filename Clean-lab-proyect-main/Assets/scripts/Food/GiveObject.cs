using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveObject : MonoBehaviour
{
	public GameObject handPoint; //punto del player donde hacemos el trigger
	public float times = 0.0f; //tiempo coger
	public float secondsGiveObject = 5.0f; //segundos de coger y dejar un objeto
	public GameObject pickedObject = null; //objeto que tiene el player
	public float timeStop = 0.0f; //tiempo parar
	public bool isDestroy = false; // si tiene un objeto cogido y esta en la papelera
	public bool giveObj = false; //si tiene un objeto el player
	public bool giveObjSpace = true;
	public CreateNewPrefab createNewPrefab; 
	public GameObject[] prefabs;
	public ParticleSystem[] patricles;
	//If is stop in area
	private List <Vector3> positions = new List<Vector3>();
	private int cont = 0;
	public float velocity = 0; 
	void Update()
	{
		if (giveObj == true) //si tiene obj el player
		{
			cont += 1;
			positions.Add(createNewPrefab.transform.position);

			if (cont != 1) // calulate velocity
			{
				Vector3 vector1 = positions[cont - 1] - positions[cont - 2];
				velocity = vector1.magnitude;
				if (velocity < 0.2f) //no hay movimiento
					timeStop += Time.deltaTime;
				else //hay movimiento
					timeStop = 0.0f;

			}
			if (cont == 2) //reste list
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
		//Debug.Log(timeStop); 
		// dejar un objeto
		if (pickedObject != null && isDestroy == false && timeStop > secondsGiveObject && giveObj == true && giveObjSpace == true)
		{
			// si el tiempo de sin movimiento es mayor a 5 y menor a 5.5 y es mayor el tiempo real del tiempo de estar parado para cogerlo y si no hay movimiento 
			pickedObject.GetComponent<Rigidbody>().useGravity = false;
			pickedObject.GetComponent<Rigidbody>().isKinematic = false;
			pickedObject.gameObject.transform.SetParent(null);
			giveObj = false;
			pickedObject = null;
		}
		if (pickedObject==null) // si no tiene nungun obj cogido que pueda coger un nuevo
			giveObj = false;


	}


	//Si el jugador esta 5 segundos encima del objeto con el tag Objects, se lo puede llevar
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Object"))
		{
			times += Time.deltaTime;

			if (times >= secondsGiveObject && times <= secondsGiveObject + 0.5f && pickedObject == null && giveObj == false)
			{

				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().isKinematic = true;
				giveObj = true;
				other.transform.position = handPoint.transform.position;
				other.gameObject.transform.SetParent(handPoint.gameObject.transform);
				pickedObject = other.gameObject;
				times = 0.0f;
			}
			//si esta en la zona de coger objetos, solo pueda coger un objeto esto es: createNewPrefab.spaceInstance == false
			if (times >= secondsGiveObject && times <= secondsGiveObject + 0.5f && giveObj == true && createNewPrefab.spaceInstance == false) //si el player ya tiene un objeto le unimos los dos o mas 
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().isKinematic = true;
				other.transform.position = handPoint.transform.position;
				other.gameObject.transform.SetParent(handPoint.gameObject.transform);
				//other.gameObject.transform.SetParent(pickedObject.gameObject.transform);
				times = 0.0f;
			}
		}

		//cambio de assets
		if (other.gameObject.CompareTag("Bubbles"))
		{ //si colisionamos con la pica i con el plato sucio creamos la animacion de burbujas y destruimos el plato
			if (pickedObject != null)
			{
				if (pickedObject.name == "Plate dirty") //Si tenemos el plato sucio lo destruimos
				{
					patricles[0].Play();
					Destroy(pickedObject);
					pickedObject = null;
					Destroy(patricles[0].gameObject, 5); //despues de 5 segundos eliminamos las burbujas
					giveObj = true;

					pickedObject = Instantiate(prefabs[0], handPoint.transform.position, Quaternion.identity);
					pickedObject.name = prefabs[0].name;
					pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);

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
					Destroy(pickedObject);
					pickedObject = null;
					Destroy(patricles[1].gameObject, 5); //despues de 5 segundos eliminamos las particulas
					giveObj = true;

					pickedObject = Instantiate(prefabs[1], handPoint.transform.position, Quaternion.identity);
					pickedObject.name = prefabs[1].name;
					pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);

				}
				if (pickedObject.name == "Salad") //Si tenemos la lechuga
				{
					patricles[2].Play();
					Destroy(pickedObject);
					pickedObject = null;
					Destroy(patricles[2].gameObject, 5); //despues de 5 segundos eliminamos las particulas
					giveObj = true;

					pickedObject = Instantiate(prefabs[2], handPoint.transform.position, Quaternion.identity);
					pickedObject.name = prefabs[2].name;
					pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);


				}
				if (pickedObject.name == "Onion") //Si tenemos la cebolla
				{
					patricles[3].Play();
					Destroy(pickedObject);
					pickedObject = null;
					Destroy(patricles[3].gameObject, 5); //despues de 5 segundos eliminamos las particulas
					giveObj = true;

					pickedObject = Instantiate(prefabs[3], handPoint.transform.position, Quaternion.identity);
					pickedObject.name = prefabs[3].name;
					pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);

				}
				if (pickedObject.name == "Cheese") //Si tenemos el queso
				{
					patricles[4].Play();
					Destroy(pickedObject);
					pickedObject = null;
					Destroy(patricles[4].gameObject, 5); //despues de 5 segundos eliminamos las particulas
					giveObj = true;

					pickedObject = Instantiate(prefabs[4], handPoint.transform.position, Quaternion.identity);
					pickedObject.name = prefabs[4].name;
					pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);

				}
				if (pickedObject.name == "Cucumber") //Si tenemos el pepino
				{
					patricles[2].Play();
					Destroy(pickedObject);
					pickedObject = null;
					Destroy(patricles[2].gameObject, 5); //despues de 5 segundos eliminamos las particulas
					giveObj = true;

					pickedObject = Instantiate(prefabs[5], handPoint.transform.position, Quaternion.identity);
					pickedObject.name = prefabs[5].name;
					pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);

				}
				//if (pickedObject.name == "Potato uncooked") //Si tenemos la patata NO FUNCIONA pq no tenemos asset de patata cortada
				//{
				//	patricles[4].Play();
				//	Destroy(pickedObject);
				//	pickedObject = null;
				//	Destroy(patricles[4].gameObject, 5); //despues de 5 segundos eliminamos las particulas
				//	giveObj = true;

				//	pickedObject = Instantiate(prefabs[6], handPoint.transform.position, Quaternion.identity);
				//	pickedObject.name = prefabs[6].name;
				 
				//	pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);

				//}
			}
		}
		if (other.gameObject.name == "PW_stove")
		{
			if (pickedObject != null)
			{
				if (pickedObject.name == "Burger UnCooked") //Si tenemos la hamburgesa cruda
				{
					patricles[5].Play();
					Destroy(pickedObject);
					pickedObject = null;
					Destroy(patricles[5].gameObject, 5); //despues de 5 segundos eliminamos las burbujas
					giveObj = true;

					pickedObject = Instantiate(prefabs[7], handPoint.transform.position, Quaternion.identity);
					pickedObject.name = prefabs[7].name;
					pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);

				}
			}
		}
		//if (other.gameObject.name == "frites Machine") para cuando tengamos el asset de las patatas crudas
		//{
		//	if (pickedObject != null)
		//	{
		//		if (pickedObject.name == "Burger UnCooked") //Si tenemos las patatas cortadas
		//		{
		//			patricles[6].Play();
		//			Destroy(pickedObject);
		//			pickedObject = null;
		//			Destroy(patricles[6].gameObject, 5); //despues de 5 segundos eliminamos las burbujas
		//			giveObj = true;

		//			pickedObject = Instantiate(prefabs[8], handPoint.transform.position, Quaternion.identity);
		//          pickedObject.name = prefabs[8].name;
		//			pickedObject.gameObject.transform.SetParent(handPoint.gameObject.transform);

		//		}
		//	}
		//}


	}
	//si no esta activado el trigger que la variable tiempo se inicialice a 0. Y la variable de tirar un objecto sea False para poder dejar un objeto nuevo que cogamos 
	private void OnTriggerExit(Collider other)
	{
		times = 0.0f;
		isDestroy = false;
		if (other.gameObject.CompareTag("SpaceInstanceFood"))
		{
			giveObjSpace = true;

		}
	}
}
