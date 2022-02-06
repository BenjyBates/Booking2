using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool tooltipOn;
    public static bool tooltipHoveredText;
    public GameObject tooltip;
    public Text tooltipText;
    
    
    public Roster roster;

    public BookingManager bookingManager;
    
    [Header("Music")]
    public AudioClip[] musicSoundtrack;
    public AudioSource MusicBG;

    private void Awake()
    {
        MusicBG.clip = musicSoundtrack[Random.Range(0, musicSoundtrack.Length)];
        MusicBG.time = Random.Range(0f, MusicBG.clip.length);
        MusicBG.Play();
    }




    private void Update()
    {


        for (int i = 0; i < bookingManager.selectWrestlerBoxes.Length; i++)
        {
            bookingManager.selectWrestlerBoxes[i].reference = roster.roster[i];
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


}
