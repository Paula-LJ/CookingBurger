using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountGiveLeaveObj : MonoBehaviour
{
    [Tooltip("Tiempo init de la acción")]
    public int timePlotGiveLeaveObj;
    private Text mytext;
    public GiveObject giveObject;
    public GameObject gameobjet;
    public CameraRotate cameraRotate; 
    private float timeText=0.0f; 
    // Start is called before the first frame update
    private void Start()
    {
        //Get the text component
        mytext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        updateCountPlot(timePlotGiveLeaveObj);

        timeText += Time.deltaTime; 

        //Rotar tambien contador del jugador rojo en su puesto
        if (gameobjet.CompareTag("Player1") && cameraRotate.timeChange!= 0.0) 
        {
            if (timeText >= cameraRotate.timeChange && timeText <= cameraRotate.timeChange + 0.5f )
            {
                mytext.transform.position = new Vector3(8, 0, 42.0f);
            }

        }
        //Rotar tambien contador del jugador azul en su puesto
        if (gameobjet.CompareTag("Player2") && cameraRotate.timeChange != 0.0)
        {

            //Debug.Log(gameObject.transform.position);
            if (timeText >= cameraRotate.timeChange && timeText <= cameraRotate.timeChange + 0.5f)
            {
                mytext.transform.position = new Vector3(7.3f, 8.0f, 80.0f);
            }

        }

    }

    public void updateCountPlot(int timePlotGiveLeaveObj)
    {
        if (giveObject.timeStop >= 1.0f && giveObject.timeStop <=5.1f && giveObject.pickedObject != null)
            mytext.text = ((int)giveObject.timeStop).ToString();
        else if (giveObject.times >= 1.0f && giveObject.times <= 5.1f && giveObject.pickedObject == null)
            mytext.text = ((int)giveObject.times).ToString();
        else
            mytext.text = "0";
    }
}
