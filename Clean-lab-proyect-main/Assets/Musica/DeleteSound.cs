using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteSound : MonoBehaviour
{
    public float life_time;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, life_time);
    }
}
