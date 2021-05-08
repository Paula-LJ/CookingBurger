using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveObject : MonoBehaviour
{
	public GameObject handPoint;
	private float times = 0.0f;
	private float secondsGiveObject = 5.0f; 
	private GameObject pickedObject = null;
	private float timeStop = 0.0f; 
	void Update()
	{
		//Debug.Log(timeStop.ToString());
		//si hay movimeineto del player
		if (handPoint.transform.hasChanged)
		{
			handPoint.transform.hasChanged = false;
			timeStop = 0.0f; 
		}
		else { //si no hay movimeinto 

			timeStop += Time.deltaTime; 
		}

		if (pickedObject !=null) 
		{
			// si el tiempo de sin movimeinto es maypr 5 y menor 5.5 y es mayor el tiempo de el tiempo de estar parado para cogerlo y si no hay movimiento 
			if (handPoint.transform.hasChanged == false && timeStop > secondsGiveObject && timeStop< secondsGiveObject +0.5f && times > secondsGiveObject +2.0f) 
			{
				pickedObject.GetComponent<Rigidbody>().useGravity = false;
				pickedObject.GetComponent<Rigidbody>().isKinematic = false;
				pickedObject.gameObject.transform.SetParent(null);
				pickedObject = null; 
			}
		}
	}


	//Si el jugador esta 5 segundos encima del objeto con el tag Objects, se lo puede llevar
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Object"))
		{
			times += Time.deltaTime;
			if (times >= secondsGiveObject && times <= secondsGiveObject + 0.5f && pickedObject == null)
			{
				other.GetComponent<Rigidbody>().useGravity = false;
				other.GetComponent<Rigidbody>().isKinematic = true;
				other.transform.position = handPoint.transform.position;
				other.gameObject.transform.SetParent(handPoint.gameObject.transform);
				pickedObject = other.gameObject;
			}
		}
	}
	//si no esta activado el trigger que la variable tiempo se inicialice a 0. 
	private void OnTriggerExit(Collider other)
	{
		times = 0.0f; 
	}
}
