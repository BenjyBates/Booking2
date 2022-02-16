using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrestler : MonoBehaviour
{
    public string wrestlerName;
    public float heat;
    public float work;
    public float skill;
    public float look;
    public TitleBelt belt;
    public bool champion;
    public Sprite head;
    public Sprite hair;
    public Sprite facialHair;
    public Sprite mask;

    public bool ismasked;


    private void Update()
    {
        if(belt != null)
        {
            champion = true;
        }
        else
        {
            champion = false;
        }

    }
}
