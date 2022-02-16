using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatchDetails : MonoBehaviour
{
    public int screen;
    public bool on;
    public GameObject holder;
    public Text match;
    public Text winner;

    public int match1winner;
    public int match2winner;
    public int match3winner;

    private void Update()
    {


        if (on)
        {
            holder.gameObject.SetActive(true);
            
            switch (screen)
            {
                case 1:
                    match.text = "OPENER";
                    break;

                case 2:
                    match.text = "MIDCARD";
                    break;

                case 3:
                    match.text = "MAIN EVENT";
                    break;
            }


        }
        else
        {
            holder.gameObject.SetActive(false);
        }



    }


    public void hide(bool set)
    {
        on = set;
    }

    public void matchType(int i)
    {
        screen = i;
    }


    public void nextButton()
    {
        switch (screen)
        {
            case 1:

                match1winner++;
                if (match1winner >= 3)
                {
                    match1winner = 0;
                }

                break;

            case 2:

                match2winner++;
                if (match2winner >= 3)
                {
                    match2winner = 0;
                }

                break;

            case 3:

                match3winner++;
                if (match3winner >= 3)
                {
                    match3winner = 0;
                }

                break;
        }
    }
}
