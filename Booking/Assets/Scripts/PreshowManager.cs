using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreshowManager : MonoBehaviour
{
    public Text confidenceText;
    public Text productText;

    public int titleWeeks;
    public Wrestler titleHolder;

    public bool objectiveCheck;

    public Text objectiveText;
    public Text objectiveTextTime;
    public Image check;
    public Color checkColorOn;
    public Color checkColorOFF;


    private void Update()
    {     
        if(titleHolder == null)
        {
            objectiveText.text = "";
            objectiveTextTime.text = "";
        }
        else
        {
            if(objectiveCheck)
            {
                check.color = checkColorOn;
            }
            else
            {
                check.color = checkColorOFF;
            }

            objectiveText.text = titleHolder.wrestlerName + " MUST BE OUR CHAMPION";
            objectiveTextTime.text = titleWeeks.ToString() + " WEEKS REMAINING...";
        }


    }

}
