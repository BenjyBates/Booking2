using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWrestlerInfo : MonoBehaviour
{
    [Header("WRESTLER TO USE")]
    public Wrestler reference;

    [Header("GameObject")]
    public GameObject holder;
    
    [Header("Heat")]
    [Header("SKILLS")]
    public Image panelHeat;
    public Text textHeat;
    [Header("Work")]
    public Image panelWork;
    public Text textWork;
    [Header("Skills")]
    public Image panelSkill;
    public Text textSkill;
    [Header("Look")]
    public Image panelLook;
    public Text textLook;

    [Header("INFORMATION")]
    public Text textWrestlerName;
    public Text textWrestlerChampion;

    [Header("PORTRAIT")]
    public Image portrait;
    public Image portraitHair;
    public Image portraitFacialHair;
    public Image portraitMask;

    [Header("COLOURS")]
    public Color colorBad;
    public Color colorBelowAverage;
    public Color colorAverage;
    public Color colorAboveAverage;
    public Color colorGreat;


    private void Update()
    {
        if (reference == null)
        {
            holder.gameObject.SetActive(false);
        }
        else
        {
            holder.gameObject.SetActive(true);


            //Name
            textWrestlerName.text = reference.wrestlerName;
            
            
            portrait.sprite = reference.head;
            portraitHair.sprite = reference.hair;
            portraitFacialHair.sprite = reference.facialHair;
            portraitMask.sprite = reference.mask;
            
            if(reference.ismasked == true)
            {
                portraitMask.gameObject.SetActive(true);
                portraitHair.gameObject.SetActive(false);
                portraitFacialHair.gameObject.SetActive(false);
            }
            else
            {
                portraitMask.gameObject.SetActive(false);
                portraitHair.gameObject.SetActive(true);
                portraitFacialHair.gameObject.SetActive(true);
            }

            if(reference.champion)
            {
                textWrestlerChampion.gameObject.SetActive(true);
                textWrestlerChampion.text = reference.belt.beltName;
            }
            else
            {
                textWrestlerChampion.gameObject.SetActive(false);
            }

            //Stats
            panelUpdater(panelHeat, reference.heat);
            textHeat.text = reference.heat.ToString("00");
            
            panelUpdater(panelWork, reference.work);
            textWork.text = reference.work.ToString("00");

            panelUpdater(panelSkill, reference.skill);
            textSkill.text = reference.skill.ToString("00");

            panelUpdater(panelLook, reference.look);
            textLook.text = reference.look.ToString("00");



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
}
