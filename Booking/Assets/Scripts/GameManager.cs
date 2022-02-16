using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{    
    public enum Screen { preshow, booking, outcome}
    public Screen screen;
    public bool clearScreen;

    public Roster roster;
    public Territory territory;
    public TitleBelt belt;

    public BookingManager bookingManager;
    public OutcomeManager outcomeManager;
    public PreshowManager preshowManager;

    public float confidence;
    public Wrestler thebest;

    [Header("Music")]
    public AudioClip[] musicSoundtrack;
    public AudioSource MusicBG;

    public Color blockColour;

    private void Awake()
    {
        //CHAMPION
        int j = Random.Range(0, roster.roster.Count);

        for (int i = 0; i < roster.roster.Count; i++)
        {
            if(i == j)
            {
                roster.roster[i].belt = belt;
            }
        }

        //SCREEN
        clearScreen = true;
     

        //ADD WRESTLERS TO GAME
        for (int i = 0; i < bookingManager.selectWrestlerBoxes.Length; i++)
        {
            
            bookingManager.selectWrestlerBoxes[i].reference = roster.roster[i];
        }

        //CREATE OBJECTIVES
        preshowManager.titleHolder = roster.roster[Random.Range(0, roster.roster.Count)];
        preshowManager.titleWeeks = Random.Range(1, 12);
        for (int i = 0; i < roster.roster.Count; i++)
        {
            if (roster.roster[i].belt != null)
            {
                if (roster.roster[i] == preshowManager.titleHolder)
                {
                    preshowManager.objectiveCheck = true;
                }
                else
                {
                    preshowManager.objectiveCheck = false;
                }
            }
        }
        preshowManager.confidenceText.text = "CONFIDENCE " + confidence.ToString("00")+"/100";

        //MUSIC
        MusicBG.clip = musicSoundtrack[Random.Range(0, musicSoundtrack.Length)];
        MusicBG.time = Random.Range(0f, MusicBG.clip.length);
        MusicBG.Play();
    }


    private void Update()
    {
        preshowManager.productText.text = "PRODUCT TYPE: " + territory.territoryProduct.ToString();


        if(clearScreen)
        {
            bookingManager.gameObject.SetActive(false);
            outcomeManager.gameObject.SetActive(false);
            preshowManager.gameObject.SetActive(false);
            clearScreen = false;
        }

        switch (screen)
        {
            case Screen.booking:
                bookingManager.gameObject.SetActive(true);
                break;

            case Screen.outcome:
                outcomeManager.gameObject.SetActive(true);
                break;

            case Screen.preshow:
                preshowManager.gameObject.SetActive(true);
                break;
        }








        //Music
        if (MusicBG.time == MusicBG.clip.length)
        {
            MusicBG.clip = musicSoundtrack[Random.Range(0, musicSoundtrack.Length)];
            MusicBG.time = 0;
            MusicBG.Play();
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            MusicBG.clip = musicSoundtrack[Random.Range(0, musicSoundtrack.Length)];
            MusicBG.time = 0;
            MusicBG.Play();
        }
    }


    public void goToOutcome()
    {

        if (bookingManager.fullyBooked == true)
        {
            float showRating;

            addWrestler(outcomeManager.openerWrestlers, 
                        bookingManager.matchCardContenderOpener1.selectedWrestler, 
                        bookingManager.matchCardContenderOpener2.selectedWrestler);

            addWrestler(outcomeManager.midcardWrestlers,
                        bookingManager.matchCardContenderMidcard1.selectedWrestler,
                        bookingManager.matchCardContenderMidcard2.selectedWrestler);

            addWrestler(outcomeManager.mainEventWrestlers,
                        bookingManager.matchCardContenderMainEvent1.selectedWrestler,
                        bookingManager.matchCardContenderMainEvent2.selectedWrestler);



            matchOutput(outcomeManager.openerWrestlers, bookingManager.matchDetails.match1winner, ref outcomeManager.outcomeMatch1, ref outcomeManager.ratingMatch1);
            matchOutput(outcomeManager.midcardWrestlers, bookingManager.matchDetails.match2winner, ref outcomeManager.outcomeMatch2, ref outcomeManager.ratingMatch2);
            matchOutput(outcomeManager.mainEventWrestlers, bookingManager.matchDetails.match3winner, ref outcomeManager.outcomeMatch3, ref outcomeManager.ratingMatch3);

            showRating = (outcomeManager.ratingMatch1 / 10f) + ((outcomeManager.ratingMatch2 / 10f) * 2) + ((outcomeManager.ratingMatch3 / 10f) * 7);
            outcomeManager.endRating = showRating;
            Debug.Log(showRating);

            outcomeManager.matchNum = 1;
            clearScreen = true;
            screen = Screen.outcome;


            
            void matchOutput(List<Wrestler> participants, int winner, ref string description, ref float rating)
            {
                description = "";

                float heat = (participants[0].heat + participants[1].heat) / 2;
                float action;
                float getBestWrestler(float stat1, float stat2)
                {
                        if (stat1 >= stat2)
                        {
                            action = stat1;
                        }
                        else
                        {
                            action = stat2;
                        }                    
                    return action;
                }
                switch (territory.territoryProduct)
                {
                    case Territory.TerritoryProduct.SOAP:
                        rating = (heat + getBestWrestler(participants[0].work, participants[0].work))/2;
                        break;

                    case Territory.TerritoryProduct.ENTERTAINMENT:
                        rating = (heat + getBestWrestler(participants[0].work, participants[0].work)) / 2;
                        break;

                    case Territory.TerritoryProduct.CLASSIC:
                        rating = (heat + getBestWrestler(participants[0].skill, participants[0].skill)) / 2;
                        break;

                    case Territory.TerritoryProduct.SPORTS:
                        rating = (heat + getBestWrestler(participants[0].skill, participants[0].skill)) / 2;
                        break;
                }

                string winner1 = participants[0].wrestlerName + " defeated " + participants[1].wrestlerName;                
                string winner2 = participants[1].wrestlerName + " defeated " + participants[0].wrestlerName;                
                
                if (winner < 3)
                {
                    //WINNER TEXT
                    if(winner == 0)
                    {
                        description += winner1;
                    }
                    else if(winner == 1)
                    {
                        description += winner2;
                    }
                    else
                    {
                        description += "ended in a no contest";
                    }

                    //TITLE CHANGE
                    for (int i = 0; i < participants.Count; i++)
                    {
                        if (participants[i].belt != null)
                        {
                            if (winner == 0)
                            {
                                participants[0].belt = belt;
                                participants[1].belt = null;
                                description += " for the " + belt.beltName;
                            }
                            else if(winner == 1)
                            {
                                participants[1].belt = belt;
                                participants[0].belt = null;
                                description += " for the " + belt.beltName;
                            }
                            else
                            {
                                description += " for the " + belt.beltName;
                            }
                        }
                    }
                }
                else
                {
                    
                }

                for (int i = 0; i < participants.Count; i++)
                {                   
                    if (participants[i].belt != null && winner < 2)
                    {

                        if (winner == 0)
                        {
                            participants[0].belt = belt;
                            participants[1].belt = null;
                        }
                        else
                        {
                            participants[1].belt = belt;
                            participants[0].belt = null;
                        }
                    }
                }
            }
            void addWrestler(List<Wrestler> wrestlers, Wrestler wrestler1, Wrestler wrestler2)
            {
                wrestlers.Add(wrestler1);
                wrestlers.Add(wrestler2);
            }
        }


    }

    public void openTab(int i)
    {
        Screen[] screens = { Screen.preshow ,Screen.booking };
        clearScreen = true;
        screen = screens[i];
    }

    public void gotoBooking()
    {
        clearScreen = true;
        screen = Screen.booking;
    }

    public void gotoObjectives()
    {
        //CLEAR OUTCOME
        if (outcomeManager.matchNum >= 5)
        {
            preshowManager.titleWeeks--;
            if(preshowManager.titleWeeks <= 0)
            {
                preshowManager.titleHolder = roster.roster[Random.Range(1, roster.roster.Count)];
                preshowManager.titleWeeks = Random.Range(0, 12);
            }
            for (int i = 0; i < roster.roster.Count; i++)
            {
                if (roster.roster[i].belt != null)
                {
                    if (roster.roster[i] == preshowManager.titleHolder)
                    {
                        preshowManager.objectiveCheck = true;
                    }
                    else
                    {
                        preshowManager.objectiveCheck = false;
                        confidence -= 25;
                    }
                }
            }
            preshowManager.confidenceText.text = "CONFIDENCE " + confidence.ToString("00") + "/100";

            bookingManager.clearbook = true;
            clearScreen = true;
            screen = Screen.preshow;

            outcomeManager.openerWrestlers.Clear();
            outcomeManager.midcardWrestlers.Clear();
            outcomeManager.mainEventWrestlers.Clear();
        }


    }
}
