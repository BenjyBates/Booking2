using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roster : MonoBehaviour
{
    [Header("Roster Settings")]
    public int rosterSize;
    public List<Wrestler> roster = new List<Wrestler>();
    public Wrestler wrestlerBase;


    [Header("Randomiser Settings")]
    public bool randomiseRoster;
    public string[] firstNames;
    public string[] lastNames;
    public Sprite[] heads;
    public Sprite[] hair;
    public Sprite[] facialHair;
    public Sprite[] mask;

    private void Awake()
    {
        if (randomiseRoster)
        {
            roster.Clear();

            for (int i = 0; i < rosterSize; i++)
            {
                roster.Add(Instantiate(randomiseWrestler(wrestlerBase, roster)));
            }
        }
    }


    public Wrestler randomiseWrestler(Wrestler wrestler, List<Wrestler> roster)
    {

        wrestler.wrestlerName = firstNames[Random.Range(0, firstNames.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)];

        for (int i = 0; i < roster.Count; i++)
        {
            if(wrestler.wrestlerName == roster[i].wrestlerName)
            {
                wrestler.wrestlerName = firstNames[Random.Range(0, firstNames.Length)] + " " + lastNames[Random.Range(0, lastNames.Length)];
            }
        }

        wrestler.heat = Random.Range(0, 100);
        
        wrestler.work = Random.Range(0, 100);
        
        wrestler.skill = Random.Range(0, 100);
        
        wrestler.look = Random.Range(0, 100);

        wrestler.head = heads[0];

        float j = Random.value;
        if(j <= .25f)
        {
            wrestler.head = heads[Random.Range(1, heads.Length)];
            wrestler.ismasked = true;
            wrestler.hair = hair[0];
            wrestler.facialHair = facialHair[0];
            wrestler.mask = mask[Random.Range(1, mask.Length)];
        }
        else
        {
            wrestler.ismasked = false;
            wrestler.hair = hair[Random.Range(0, hair.Length)];
            wrestler.facialHair = facialHair[Random.Range(0, facialHair.Length)];
            wrestler.mask = mask[0];
        }

        //wrestler.morale = Random.Range(0, 100);
        //wrestler.relationship = Random.Range(0, 100);
       
        wrestler.head = heads[Random.Range(0, heads.Length)];

        return wrestler;
    }

}