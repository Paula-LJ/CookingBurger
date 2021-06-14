using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnTrigger : MonoBehaviour
{
    private bool isCollidedWithObj1;
    private bool isCollidedWithObj2;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player1"))
            isCollidedWithObj1 = true;
        else if (collision.CompareTag("Player2"))
            isCollidedWithObj2 = true;

        if (isCollidedWithObj1 && isCollidedWithObj2)
            Destroy(gameObject);
    }

}
