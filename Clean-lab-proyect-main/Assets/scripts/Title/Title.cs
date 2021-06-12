using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public string sceneToChangeTo;

    private bool isCollidedWithObj1;
    private bool isCollidedWithObj2;
    
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player1"))
            isCollidedWithObj1 = true;
        else if (collision.CompareTag("Player2"))
            isCollidedWithObj2 = true;

        if (isCollidedWithObj1 && isCollidedWithObj2)
            SceneManager.LoadScene(sceneToChangeTo);
    }
}
