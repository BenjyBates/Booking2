using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VenueSelect : MonoBehaviour
{
    public Venue venue;
    public Text venueText;
    public Text venueTextInfo;
    public Image venuePanel;
    public Text venueRating;
    public bool selected;
    public Button button;


    [Header("COLOURS")]
    public Color colorBad;
    public Color colorBelowAverage;
    public Color colorAverage;
    public Color colorAboveAverage;
    public Color colorGreat;
    public Color colorpressed;
    public Color colornot;


    int fontsize;

    private void Awake()
    {
        fontsize = venueText.fontSize;
    }

    private void Update()
    {
        if(selected)
        {
            venueText.color = colorpressed;
            venueText.fontSize = fontsize + 1;
            venueTextInfo.color = colorpressed;
        }
        else
        {
            venueText.color = colornot;
            venueText.fontSize = fontsize;
            venueTextInfo.color = colornot;
        }

        if(button.interactable)
        {
            venueText.text = venue.venueName; 
            venueTextInfo.text = "MIN REQUIRED SHOW RATING";
        }
        else
        {
            venueText.text = "COMPANY PRESTIGE TOO LOW";
            venueTextInfo.text = "";
            venueTextInfo.color = colornot;
        }

        venueRating.text = venue.venueRating.ToString("00");

        panelUpdater(venuePanel, venue.venueRating);


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
