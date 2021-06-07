using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public AudioClip moneySound;
    public GiveObject giveObject;
    public float timeDestroy;

    private AudioSource sound;
    private GameObject childother;

    public Spawn spawn; 
    //&& giveObject.pickedObject!=null

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) //other es la otra cosa con la que colisiona
    {
        if (other.CompareTag("Object"))
        {
            childother = other.transform.GetChild(0).gameObject;
            
            if (childother.CompareTag("Burger"))
            {
                sound.PlayOneShot(moneySound, 0.2f);
                Destroy(gameObject, timeDestroy); //Desaparegui el client amb cert retard per tal que sonin els diners
            }

            //FALTARIA COMPARA SI ÉS O NO L'HAMBURGUESA DEMANADA 
			for (int i = 0; i < 4; i++) //Comparar lo que lleva encima con lo que piede el cliente
			{
                if (spawn.clients[0].ingredients[i].name == other.name)
					Debug.Log("ES");
			}
			//Destrueix l'objecte entregat (sigui o no el que ha demanat)
			giveObject.giveObj = false;
            Destroy(other.gameObject);
            giveObject.pickedObject = null;
        }
    }
}
