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
	public ParticleSystem bubbles;
	//public bool giveObjectInstanceSpace = false; 
	void Update()
	{
		//Debug.Log(times); 
		//si hay movimiento del player
		if (handPoint.transform.hasChanged)
		{
			handPoint.transform.hasChanged = false;
			timeStop = 0.0f;
			//times = 0.0f; //si hay movimiento que el tiempo de coger sea 0

		}
		else
		{ //si no hay movimiento, el tiempo de stop augmente
			if (giveObj == true)
				timeStop += Time.deltaTime;
		}
		// dejar un objeto
		if (pickedObject != null && isDestroy == false && handPoint.transform.hasChanged == false &&
			timeStop > secondsGiveObject && timeStop < secondsGiveObject + 0.5f && giveObj == true && giveObjSpace == true)
		{
			// si el tiempo de sin movimiento es mayor a 5 y menor a 5.5 y es mayor el tiempo real del tiempo de estar parado para cogerlo y si no hay movimiento 
			pickedObject.GetComponent<Rigidbody>().useGravity = false;
			pickedObject.GetComponent<Rigidbody>().isKinematic = false;
			pickedObject.gameObject.transform.SetParent(null);
			//pickedObject.gameObject.transform.position += new Vector3(1, 0, 0); //para ver fisicamente que lo ha cogido /mueve el objeto una posicion en la derecha
			giveObj = false;
			pickedObject = null;


		}
		//if (pickedObject != null && isDestroy == false && handPoint.transform.hasChanged == false &&
		//	timeStop > secondsGiveObject && timeStop < secondsGiveObject + 0.5f && giveObj == true && giveObjSpace == true)
		//{
		//	if (pickedObject.name == "Plate dirty") //Si tenemos el plato sucio lo destruimos
		//          {
		//		Destroy(pickedObject);
		//		giveObj = false;
		//		pickedObject = null;
		//		giveObj = false;

		//	}


		//}

	}


	//Si el jugador esta 5 segundos encima del objeto con el tag Objects, se lo puede llevar
	private void OnTriggerStay(Collider other)
	{
		//Dejar objeto en el suelo
		if (other.gameObject.CompareTag("Floor"))
		{
			if (pickedObject != null && isDestroy == false && handPoint.transform.hasChanged == false &&
			timeStop > secondsGiveObject && timeStop < secondsGiveObject + 0.5f && giveObj == true && giveObjSpace == true)
			{
				// si el tiempo de sin movimiento es mayor a 5 y menor a 5.5 y es mayor el tiempo real del tiempo de estar parado para cogerlo y si no hay movimiento 
				pickedObject.GetComponent<Rigidbody>().useGravity = false;
				pickedObject.GetComponent<Rigidbody>().isKinematic = false;
				pickedObject.gameObject.transform.SetParent(null);
				//pickedObject.gameObject.transform.position += new Vector3(1, 0, 0); //para ver fisicamente que lo ha cogido /mueve el objeto una posicion en la derecha
				giveObj = false;
				pickedObject = null;
			}
		}

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
			if (times >= secondsGiveObject && times <= secondsGiveObject + 0.5f  && giveObj == true && createNewPrefab.spaceInstance == false) //si el player ya tiene un objeto le unimos los dos o mas 
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().isKinematic = true;
				other.transform.position = handPoint.transform.position;
				other.gameObject.transform.SetParent(handPoint.gameObject.transform);
				other.gameObject.transform.SetParent(pickedObject.gameObject.transform);
				times = 0.0f;
			}
		}
		if (other.gameObject.CompareTag("DestroyFood"))
		{
			isDestroy = true;
			times += Time.deltaTime;
			if (handPoint.transform.hasChanged == false && timeStop > secondsGiveObject && timeStop < secondsGiveObject + 0.5f && giveObj == true)
			{

				for (int i = 0; i < pickedObject.gameObject.transform.childCount; i++)
				{
					if (pickedObject.gameObject.transform.GetChild(i).tag == "Object")
						Destroy(pickedObject.gameObject.transform.GetChild(i).gameObject);
				}

				Destroy(pickedObject);
				giveObj = false;
				pickedObject = null;
				giveObj = false;


			}
		}

		if (other.gameObject.CompareTag("Bubbles")){ //si colisionamos con la pica i con el plato sucio creamos la animacion de burbujas y destruimos el plato
			if (pickedObject != null)
            {
				if (pickedObject.name == "Plate dirty") //Si tenemos el plato sucio lo destruimos
				{

					bubbles.Play();
					Destroy(pickedObject);
					giveObj = false;
					pickedObject = null;
					giveObj = false;

					Destroy(bubbles.gameObject, 5); //despues de 5 segundos eliminamos las burbujas
				}
			}
		}
			
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
