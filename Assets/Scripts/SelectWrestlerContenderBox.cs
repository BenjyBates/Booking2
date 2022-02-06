using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWrestlerContenderBox : MonoBehaviour
{
    public BoxCollider2D col2D;

    public Wrestler reference;

    public Image bg;
    public Text text;

    public bool selecting;
    public bool selectCheck;

    public Color highlight;
    public Color idle;


    private void Awake()
    {
        col2D = GetComponent<BoxCollider2D>();
        bg.color = idle;
        text.text = "";

    }

    private void Update()
    {
        if(selecting)
        {
            if(BookingManager.click != null)
            {
                reference = BookingManager.click;
                bg.color = idle;
                selecting = false;

            }
            else
            {
                bg.color = highlight;
                text.text = "SELECTING...";
            }
        }
        else
        {
            text.text = reference.wrestlerName;
        }
    }


    private void OnMouseEnter()
    {
        if(reference == null)
        {

        }
        else
        {
            BookingManager.hover = reference;
        }


        bg.color = highlight;
    }

    private void OnMouseExit()
    {
        bg.color = idle;
    }



    private void OnMouseUp()
    {
        if(!selecting)
        {
            selecting = true;
            BookingManager.click = null;

        }
        else
        {
            selecting = false;

        }
    }

}
