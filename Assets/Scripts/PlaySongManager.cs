using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaySongManager : MonoBehaviour
{
    public Manager manager;
    public GameObject selectedSong;
    public AudioSource theMottoAudio;
    public AudioSource flashingLightsAudio;
    public GameObject theMottoMap;
    public GameObject flashingLightsMap;
    private void Start()
    {
        SelectSong(selectedSong);
    }
    public void SelectSong(GameObject song)
    {
        selectedSong.GetComponent<Image>().color = Color.blue;
        song.GetComponent<Image>().color = Color.red;
        selectedSong = song;
    }
    
}
