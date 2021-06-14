using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerFin : MonoBehaviour
{
    public static BurgerFin Instance;
    public GameObject burger;
    private bool aux;

    void Awake()
    {
        Instance = this;
        aux = false;
    }

    public bool IsBurger() 
    {
        burger = transform.GetChild(0).gameObject;
        if (burger.CompareTag("Burger"))
            aux = true;
        return aux;
    }


}
