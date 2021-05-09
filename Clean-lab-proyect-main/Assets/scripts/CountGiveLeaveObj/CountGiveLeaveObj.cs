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

    }

    public void updateCountPlot(int timePlotGiveLeaveObj)
    {
        if (giveObject.timeStop >= 1.0f && giveObject.timeStop <=5.1f && giveObject.pickedObject != null)
            mytext.text = ((int)giveObject.timeStop).ToString();
        else if (giveObject.times >= 1.0f && giveObject.times <= 5.1f)
            mytext.text = ((int)giveObject.times).ToString();
        else
            mytext.text = "0";
    }
}
