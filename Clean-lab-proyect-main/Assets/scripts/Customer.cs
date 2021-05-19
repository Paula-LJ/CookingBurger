using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    public AudioClip moneySound;

    private AudioSource sound;
    private bool burgerAux = false;
    private float time = 0.0f;
    private float timeStop = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Object"))
        {
            time += Time.deltaTime;
            burgerAux = BurgerFin.Instance.IsBurger();
            Debug.Log(burgerAux);
            if (burgerAux==true && time > timeStop && time < timeStop + 0.5f)
            {
                sound.PlayOneShot(moneySound, 0.2f);
            }
            
        }
    }
}
