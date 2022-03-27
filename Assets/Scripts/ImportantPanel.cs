using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImportantPanel : MonoBehaviour
{
    public float[] numRatings;    
    public Text currentVenue;
    public Text currentDate;
    public Text[] card;
    public Text[] textRatings;       
    public Image[] panels;

    [Header("COLOURS")]
    public Color colorBad;
    public Color colorBelowAverage;
    public Color colorAverage;
    public Color colorAboveAverage;
    public Color colorGreat;

    void Update()
    {
        for (int i = 0; i < numRatings.Length; i++)
        {
            panelUpdater(panels[i], numRatings[i]);
        }


        void panelUpdater(Image panel, float stat)
        {
            if (stat <= 20)
            {
                panel.color = colorBad;
            }
            else if (stat <= 50)
            {
                panel.color = colorBelowAverage;
            }
            else if (stat <= 70)
            {
                panel.color = colorAverage;
            }
            else if (stat <= 90)
            {
                panel.color = colorAboveAverage;
            }
            else
            {
                panel.color = colorGreat;
            }

        }
    }
}
