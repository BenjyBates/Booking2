using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchDetails : MonoBehaviour
{
    public bool on;
    public GameObject holder;

    private void Update()
    {
        if(on)
        {
            holder.gameObject.SetActive(true);
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

}
