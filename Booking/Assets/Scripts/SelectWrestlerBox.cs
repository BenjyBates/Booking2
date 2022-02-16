using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectWrestlerBox : MonoBehaviour
{

    public Text text;
    private int textSize;
    private int textSizeHover;
    
    public bool hovered;
    public bool selected;
    public Image panel;
    public Wrestler reference;


    private void Awake()
    {
        textSize = text.fontSize;
        textSizeHover = textSize + 1;
    }

    private void Update()
    {
        if(reference == null)
        {
            text.text = "";
        }
        else
        {
            text.text = reference.wrestlerName;
        }
    }

    private void OnMouseEnter()
    {
        hovered = true;
        text.fontSize = textSizeHover;

    }

    private void OnMouseExit()
    {
        hovered = false;
        text.fontSize = textSize;
    }

    private void OnMouseUp()
    {
        selected = true;
    }
}
