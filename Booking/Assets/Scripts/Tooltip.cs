using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public GameObject tooltip;

    public Text tooltipText;

    private void Awake()
    {
        tooltip.gameObject.SetActive(false);
    }


    public void OnMouseOver()
    {
        tooltip.gameObject.SetActive(true);
    }
    private void OnMouseExit()
    {
        tooltip.gameObject.SetActive(false);
    }

}
