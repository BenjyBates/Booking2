using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonMatchcardContender : MonoBehaviour
{
    public Wrestler selectedWrestler;
    public Text text;

    public bool selecting;
    public bool hovering;

    public Color champColor;
    private Color defaultColor;

    private void Awake()
    {
        defaultColor = text.color;

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
            text.color = defaultColor;
            text.text = "SELECTING...";
        }
        else
        {
            if (selectedWrestler == null)
            {
                text.text = "";
            }
            else
            {
                if(selectedWrestler.belt != null)
                {
                    text.color = champColor;
                }
                else
                {
                    text.color = defaultColor;
                }

                text.text = selectedWrestler.wrestlerName;
            }
        }
    }



    public void select()
    {
        if (!selecting)
        {
            selectedWrestler = null;
            selecting = true;          

        }
        else
        {
            selecting = false;

        }
    }


    private void OnMouseOver()
    {
        if (selectedWrestler == null)
        {

        }
        else
        {
            hovering = true;
        }
    }

    private void OnMouseExit()
    {
        hovering = false;
    }
}
