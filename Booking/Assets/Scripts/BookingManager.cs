using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookingManager : MonoBehaviour
{
    public static Wrestler click;
    public static Wrestler hover;

    public Wrestler referenceWrestler;

    //ROSTER
    public SelectWrestlerBox[] selectWrestlerBoxes;

    //INFO
    public SelectWrestlerInfo infoBox;
    public MatchDetails matchDetails;

    //MATCH CARD
    public ButtonMatchcardContender matchCardContenderMainEvent1;
    public ButtonMatchcardContender matchCardContenderMainEvent2;
    public ButtonMatchcardContender matchCardContenderMidcard1;
    public ButtonMatchcardContender matchCardContenderMidcard2;
    public ButtonMatchcardContender matchCardContenderOpener1;
    public ButtonMatchcardContender matchCardContenderOpener2;
    public bool fullyBooked;
    public bool clearbook;

    public Text win1;
    public Text win2;
    public Text win3;

    public Color colorHighlighted;
    public Color colorDark;

    private void Update()
    {
        if(hover == null)
        {

        }
        else
        {
            infoBox.reference = hover;
        }

        if(referenceWrestler == null)
        {

        }

        Wrestler[] participants = { matchCardContenderMainEvent1.selectedWrestler,
                                    matchCardContenderMainEvent2.selectedWrestler,
                                    matchCardContenderMidcard1.selectedWrestler,
                                    matchCardContenderMidcard2.selectedWrestler,
                                    matchCardContenderOpener1.selectedWrestler,
                                    matchCardContenderOpener2.selectedWrestler};
        

        //FULLY BOOKED LOGIC
        if (matchCardContenderMainEvent1.selectedWrestler
            && matchCardContenderMainEvent2.selectedWrestler
            && matchCardContenderMidcard1.selectedWrestler
            && matchCardContenderMidcard2.selectedWrestler
            && matchCardContenderOpener1.selectedWrestler
            && matchCardContenderOpener2.selectedWrestler != null)
        {
            if(matchCardContenderMainEvent1.selectedWrestler != matchCardContenderMainEvent2.selectedWrestler 
                && matchCardContenderMidcard1.selectedWrestler != matchCardContenderMidcard2.selectedWrestler
                && matchCardContenderOpener1.selectedWrestler != matchCardContenderOpener2.selectedWrestler)
            {
                fullyBooked = true;
            }
        }
        else
        {
            fullyBooked = false;  
        }


        switch (matchDetails.screen)
        {
            case 1:
                if (matchCardContenderOpener1.selectedWrestler && matchCardContenderOpener2.selectedWrestler != null)
                {
                    switch (matchDetails.match1winner)
                    {
                        case 0:
                            matchDetails.winner.text = matchCardContenderOpener1.selectedWrestler.wrestlerName;
                            win1.text = matchCardContenderOpener1.selectedWrestler.wrestlerName;
                            break;

                        case 1:
                            matchDetails.winner.text = matchCardContenderOpener2.selectedWrestler.wrestlerName;
                            win1.text = matchCardContenderOpener2.selectedWrestler.wrestlerName;
                            break;

                        case 2:
                            matchDetails.winner.text = "DRAW";
                            win1.text = "DRAW";
                            break;
                    }
                }
                else
                {
                    matchDetails.winner.text = "";
                    win1.text = "";
                }

                break;

            case 2:
                if (matchCardContenderMidcard1.selectedWrestler && matchCardContenderMidcard2.selectedWrestler != null)
                {
                    switch (matchDetails.match2winner)
                    {
                        case 0:
                            matchDetails.winner.text = matchCardContenderMidcard1.selectedWrestler.wrestlerName;
                            win2.text = matchCardContenderMidcard1.selectedWrestler.wrestlerName;
                            break;

                        case 1:
                            matchDetails.winner.text = matchCardContenderMidcard2.selectedWrestler.wrestlerName;
                            win2.text = matchCardContenderMidcard2.selectedWrestler.wrestlerName;
                            break;

                        case 2:
                            matchDetails.winner.text = "DRAW";
                            win2.text = "DRAW";
                            break;
                    }
                }
                else
                {
                    matchDetails.winner.text = "";
                    win2.text = "";
                }

                break;

            case 3:
                if (matchCardContenderMainEvent1.selectedWrestler && matchCardContenderMainEvent2.selectedWrestler != null)
                {
                    switch (matchDetails.match3winner)
                    {
                        case 0:
                            matchDetails.winner.text = matchCardContenderMainEvent1.selectedWrestler.wrestlerName;
                            win3.text = matchCardContenderMainEvent1.selectedWrestler.wrestlerName;
                            break;

                        case 1:
                            matchDetails.winner.text = matchCardContenderMainEvent2.selectedWrestler.wrestlerName;
                            win3.text = matchCardContenderMainEvent2.selectedWrestler.wrestlerName;
                            break;

                        case 2:
                            matchDetails.winner.text = "DRAW";
                            win3.text = "DRAW";
                            break;
                    }
                }
                else
                {
                    matchDetails.winner.text = "";
                    win3.text = "";
                }

                break;
        }



        //HOVER
        //MAIN EVENT
        if(matchCardContenderMainEvent1.hovering)
        {
            infoBox.reference = matchCardContenderMainEvent1.selectedWrestler;
        }
        else if(matchCardContenderMainEvent2.hovering)
        {
            infoBox.reference = matchCardContenderMainEvent2.selectedWrestler;
        }
        //MIDCARD
        if(matchCardContenderMidcard1.hovering)
        {
            infoBox.reference = matchCardContenderMidcard1.selectedWrestler;
        }
        else if(matchCardContenderMidcard2.hovering)
        {
            infoBox.reference = matchCardContenderMidcard2.selectedWrestler;
        }
        //OPENER
        if (matchCardContenderOpener1.hovering)
        {
            infoBox.reference = matchCardContenderOpener1.selectedWrestler;
        }
        else if (matchCardContenderOpener2.hovering)
        {
            infoBox.reference = matchCardContenderOpener2.selectedWrestler;
        }


        //ROSTER LOGIC
        for (int i = 0; i < selectWrestlerBoxes.Length; i++)
        {
            //SELECT WRESTLER
            if(selectWrestlerBoxes[i].selected)
            {
                referenceWrestler = selectWrestlerBoxes[i].reference;

                //MAIN EVENT
                if (matchCardContenderMainEvent1.selecting)
                {
                    matchCardContenderMainEvent1.selectedWrestler = referenceWrestler;
                    matchCardContenderMainEvent1.selecting = false;
                }
                else if(matchCardContenderMainEvent2.selecting)
                {
                    matchCardContenderMainEvent2.selectedWrestler = referenceWrestler;
                    matchCardContenderMainEvent2.selecting = false;
                }

                //MIDCARD
                if (matchCardContenderMidcard1.selecting)
                {
                    matchCardContenderMidcard1.selectedWrestler = referenceWrestler;
                    matchCardContenderMidcard1.selecting = false;
                }
                else if (matchCardContenderMidcard2.selecting)
                {
                    matchCardContenderMidcard2.selectedWrestler = referenceWrestler;
                    matchCardContenderMidcard2.selecting = false;
                }

                //OPENER
                if (matchCardContenderOpener1.selecting)
                {
                    matchCardContenderOpener1.selectedWrestler = referenceWrestler;
                    matchCardContenderOpener1.selecting = false;
                }
                else if (matchCardContenderOpener2.selecting)
                {
                    matchCardContenderOpener2.selectedWrestler = referenceWrestler;
                    matchCardContenderOpener2.selecting = false;
                }

                selectWrestlerBoxes[i].selected = false;

            }
            
            //HOVER
            if(selectWrestlerBoxes[i].hovered == true)
            {
                selectWrestlerBoxes[i].panel.color = colorHighlighted;
                infoBox.reference = selectWrestlerBoxes[i].reference;
            }
            else
            {
                selectWrestlerBoxes[i].panel.color = colorDark;
            }

        }




        if(clearbook)
        {
            clearSelection();
            clearbook = false;
        }
    }

    public void clearSelection()
    {
        for (int i = 0; i < selectWrestlerBoxes.Length; i++)
        {
            selectWrestlerBoxes[i].selected = false;
        }

        matchCardContenderMainEvent1.selectedWrestler = null;
        matchCardContenderMainEvent2.selectedWrestler = null;
        matchCardContenderMidcard1.selectedWrestler = null;
        matchCardContenderMidcard2.selectedWrestler = null;
        matchCardContenderOpener1.selectedWrestler = null;
        matchCardContenderOpener2.selectedWrestler = null;
    }
}
