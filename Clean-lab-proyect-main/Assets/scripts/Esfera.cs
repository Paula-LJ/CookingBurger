using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esfera : MonoBehaviour
{

    public float destroyDelay;
    private bool hitByPlayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HitByPlayers()
    {
        hitByPlayers = true;
        Destroy(gameObject, destroyDelay);
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other.CompareTag("Player1") && other.CompareTag("Player2") && !hitByPlayers)
        {
            Destroy(other.gameObject); 
            HitByPlayers(); 
        }
    }
}
