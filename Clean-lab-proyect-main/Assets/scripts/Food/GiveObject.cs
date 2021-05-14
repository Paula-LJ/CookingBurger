﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveObject : MonoBehaviour
{
	public GameObject handPoint; //punto del player donde hacemos el trigger
	public float times = 0.0f; //tiempo coger
	private float secondsGiveObject = 5.0f; //segundos de coger y dejar un objeto
	public GameObject pickedObject = null; // lista de objetos que tiene el player
	public float timeStop = 0.0f; //tiempo parar
	private bool isDestroy = false; // si tiene un objeto cogido y esta en la papelera
	private bool giveObj = false; //si tiene un objeto el player

	void Update()
	{
		//si hay movimeineto del player
		if (handPoint.transform.hasChanged)
		{
			handPoint.transform.hasChanged = false;
			timeStop = 0.0f; 
		}
		else { //si no hay movimeinto, el tiempo de stop augmente
			if(giveObj == true)
				timeStop += Time.deltaTime; 
		}
		// dejar un objeto
		if (pickedObject != null && isDestroy==false && handPoint.transform.hasChanged == false && 
			timeStop > secondsGiveObject && timeStop < secondsGiveObject + 0.5f && giveObj == true) 
        {
			// si el tiempo de sin movimeinto es mayor a 5 y menor a 5.5 y es mayor el tiempo real del tiempo de estar parado para cogerlo y si no hay movimiento 
            pickedObject.GetComponent<Rigidbody>().useGravity = false;
            pickedObject.GetComponent<Rigidbody>().isKinematic = false;
            pickedObject.gameObject.transform.SetParent(null);
            pickedObject.gameObject.transform.position +=new Vector3(1,0,0); //para ver fisicamente que lo ha cogido /mueve el objeto una posicion en la derecha
			giveObj = false; 
			pickedObject = null;
            
        }

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
			}
		}
        if (other.gameObject.CompareTag("DestroyFood"))
        {
			isDestroy = true;
            times += Time.deltaTime;
            if (handPoint.transform.hasChanged == false && timeStop > secondsGiveObject && timeStop < secondsGiveObject + 0.5f && giveObj == true)
            {
				giveObj = false;
				Destroy(pickedObject);
				pickedObject = null;
			}
		}
    }
	//si no esta activado el trigger que la variable tiempo se inicialice a 0. Y la variable de tirar un objecto sea False para poder dejar un objeto nuevo que cogamos 
	private void OnTriggerExit(Collider other)
	{
		times = 0.0f;
		isDestroy = false;
	}
}
