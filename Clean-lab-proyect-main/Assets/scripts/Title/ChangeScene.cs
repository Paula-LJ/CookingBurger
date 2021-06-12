using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneToChangeTo_win;
    public string sceneToChangeTo_loose;

    public Customer customer;
    public rotateScene rotatescene;

    private int customerOut = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(customer.OneRandom);

        if (customer.OneRandom == true) //No funciona
        {
            customerOut += 1;

            if (customerOut == 1)
            {
                //SceneManager.LoadScene(sceneToChangeTo_win);
                //Debug.Log(customer.customerOut);
                Debug.Log("HOLA");
            }
            
        }

        if ( rotatescene.time >= (rotatescene.timeChange * 2) && rotatescene.time <= (rotatescene.timeChange * 2) + 0.5f)
        {
            SceneManager.LoadScene(sceneToChangeTo_loose);
        }
    }
}
