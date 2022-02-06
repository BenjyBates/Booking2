using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMatchcardContender : MonoBehaviour
{
    public Wrestler selectedWrestler;
    public Text text;

    public bool selecting;
    public bool selectCheck;
    public bool selectClear;


    private void Awake()
    {
        if (selectedWrestler == null)
        {
            text.text = "";
        }
        else
        {
            text.text = selectedWrestler.wrestlerName;
        }
    }

    private void Update()
    {
        if (selecting)
        {
            if (BookingManager.click != null)
            {
                selectedWrestler = BookingManager.click;
                selectCheck = true;
                selecting = false;

            }
            else
            {
                text.text = "SELECTING...";
            }
        }
        else
        {
            text.text = selectedWrestler.wrestlerName;
        }
    }



    public void select()
    {
        if (!selecting)
        {
            selecting = true;
            
            BookingManager.click = null;
            
            if (selectedWrestler != null)
            {
                selectClear = true;
            }

        }
        else
        {
            selecting = false;

        }
    }


    private void OnMouseEnter()
    {
        if (selectedWrestler == null)
        {

        }
        else
        {
            BookingManager.hover = selectedWrestler;
        }
    }

}
