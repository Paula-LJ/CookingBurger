using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private Collider myCollider;
    private Rigidbody myRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        myCollider = GetComponent<Collider>();
        myRigidbody = GetComponent<Rigidbody>();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Burger"))
        {
            Debug.Log("entra_if");
            BugerDelivered();
        }
    }

    private void BugerDelivered() 
    {
        Debug.Log("entra_musica");
        SoundManager.Instance.PlayMoneyClip();
    }
}
