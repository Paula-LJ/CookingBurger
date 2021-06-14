using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountArrow : MonoBehaviour
{
    [Tooltip("Tiempo inicial en segundos")]
    public int TimeInitial;
    private Text myText;
    public rotateScene rotateS; 
    public Arrow arrow;
    private float ContShow;  
    void Start()
    {
        ContShow = arrow.timeAppeareArrow+1; // por el int que redondea hacia abajo
        myText = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        ContShow -= Time.deltaTime;
        if (rotateS.timeChange - arrow.timeAppeareArrow <= rotateS.time && rotateS.timeChange >= rotateS.time)
            myText.text = ((int)(rotateS.timeChange -arrow.timeAppeareArrow + ContShow)).ToString();
        else
            myText.text = "";
    }
}
