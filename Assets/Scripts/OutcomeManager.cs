using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutcomeManager : MonoBehaviour
{
    public enum outcomeStage { match, end}
    public outcomeStage stage;

    public GameObject holder;

    public int matchNum;

    public List<Wrestler> mainEventWrestlers = new List<Wrestler>();
    public List<Wrestler> midcardWrestlers = new List<Wrestler>();
    public List<Wrestler> openerWrestlers = new List<Wrestler>();

    private Wrestler currentWrestler;
    public float matchRating;
    public float endRating;
    public string description;

    [Header("INFORMATION")]
    public Text textMatch;
    public Text textRating;
    public Text textRatingShow;
    public Text textDescription;
    public Text textTitle;
    public Image panel;
    public Image panelShow;

    public Text textWrestlerName1;
    public Text textWrestlerName2;

    [Header("PORTRAIT")]
    public Image portrait1;         
    public Image portraitHair1;
    public Image portraitFacialHair1;
    public Image portraitMask1;
    public Image portrait2;
    public Image portraitHair2;
    public Image portraitFacialHair2;
    public Image portraitMask2;

    [Header("COLOURS")]
    public Color colorBad;
    public Color colorBelowAverage;
    public Color colorAverage;
    public Color colorAboveAverage;
    public Color colorGreat;

    public float ratingMatch1;
    public float ratingMatch2;
    public float ratingMatch3;
    public string outcomeMatch1;
    public string outcomeMatch2;
    public string outcomeMatch3;

    private void Update()
    {


        void champCheck(List<Wrestler> list)
        {
            if (list[0].belt != null)
            {
                textTitle.text = list[0].belt.beltName;
                textTitle.gameObject.SetActive(true);
            }
            else if (list[1].belt != null)
            {
                textTitle.text = list[1].belt.beltName;
                textTitle.gameObject.SetActive(true);
            }
            else
            {
                textTitle.gameObject.SetActive(false);
            }
        }

        switch (matchNum)
        {

            case 1:
                holder.gameObject.SetActive(true);
                panelShow.gameObject.SetActive(false);

                if (openerWrestlers != null)
                {
                    updateUI(openerWrestlers[0], portrait1, portraitHair1, portraitFacialHair1, portraitMask1, textWrestlerName1);
                    updateUI(openerWrestlers[1], portrait2, portraitHair2, portraitFacialHair2, portraitMask2, textWrestlerName2);                    
                    matchRating = ratingMatch1;

                    champCheck(openerWrestlers);
                }

                textDescription.text = outcomeMatch1;
                textMatch.text = "OPENER";

                break;
            
            case 2:
                if(midcardWrestlers != null)
                {
                    updateUI(midcardWrestlers[0], portrait1, portraitHair1, portraitFacialHair1, portraitMask1, textWrestlerName1);
                    updateUI(midcardWrestlers[1], portrait2, portraitHair2, portraitFacialHair2, portraitMask2, textWrestlerName2);
                    matchRating = ratingMatch2;

                    champCheck(midcardWrestlers);
                }

                textDescription.text = outcomeMatch2;
                textMatch.text = "MIDCARD";

                break;
            
            case 3:
                if(mainEventWrestlers != null)
                {
                    updateUI(mainEventWrestlers[0], portrait1, portraitHair1, portraitFacialHair1, portraitMask1, textWrestlerName1);
                    updateUI(mainEventWrestlers[1], portrait2, portraitHair2, portraitFacialHair2, portraitMask2, textWrestlerName2);
                    matchRating = ratingMatch3;

                    champCheck(mainEventWrestlers);
                }

                textDescription.text = outcomeMatch3;
                textMatch.text = "MAIN EVENT";

                break;

            case 4:
                holder.gameObject.SetActive(false);
                panelShow.gameObject.SetActive(true);
                break;
        }

        textRatingShow.text = endRating.ToString("00");
        textRating.text = matchRating.ToString("00");
        panelUpdater(panel, matchRating);
        panelUpdater(panelShow, endRating);


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


    public void updateUI(Wrestler wrestler, Image head, Image hair, Image beard, Image mask, Text name)
    {
        name.text = wrestler.wrestlerName;
        head.sprite = wrestler.head;
        hair.sprite = wrestler.hair;
        beard.sprite = wrestler.head;
        mask.sprite = wrestler.mask;

        if(wrestler.ismasked == true)
        {
            mask.gameObject.SetActive(true);
            hair.gameObject.SetActive(false);
            beard.gameObject.SetActive(false);
        }
        else
        {
            mask.gameObject.SetActive(false);
            hair.gameObject.SetActive(true);
            beard.gameObject.SetActive(true);
        }
    }

    public void next()
    {
        matchNum++;
    }


}
