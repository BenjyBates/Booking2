using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookingManager : MonoBehaviour
{
    public static Wrestler click;
    public static Wrestler hover;

    public SelectWrestlerBox[] selectWrestlerBoxes;
    public SelectWrestlerInfo infoBox;
    public SelectWrestlerMatch matchCard;


    [Header("Main Event")]
    public ButtonMatchcardContender mainEvent1;
    public ButtonMatchcardContender mainEvent2;
    public List<Wrestler> mainEventSelected = new List<Wrestler>(2);
    private bool mainEventUpdate;
    
    public Color colorHighlighted;
    public Color colorDark;

    private void Update()
    {
        infoBox.reference = hover;

        if(mainEvent1.selectCheck)
        {
            updateChallenger(mainEventSelected, mainEvent1.selectedWrestler);
            mainEvent1.selectCheck = false;
        }
        else if(mainEvent1.selectClear)
        {
            mainEventSelected.Remove(mainEvent1.selectedWrestler);
            mainEvent1.selectedWrestler = null;
            mainEvent1.selectCheck = false;
        }

        if (mainEvent2.selectCheck)
        {
            updateChallenger(mainEventSelected, mainEvent2.selectedWrestler);
            mainEvent2.selectCheck = false;
        }

        if (click == null)
        {

        }






        for (int i = 0; i < selectWrestlerBoxes.Length; i++)
        {



            //Highlight
            if(selectWrestlerBoxes[i].hovered == true)
            {
                selectWrestlerBoxes[i].panel.color = colorHighlighted;
                //infoBox.reference = selectWrestlerBoxes[i].reference;
            }
            else
            {
                selectWrestlerBoxes[i].panel.color = colorDark;
            }
        }
    }


    public void updateChallenger(List<Wrestler> pool, Wrestler selected)
    {
        if(pool.Count < 2)
        {
            pool.Add(selected);
        }
    }
}
