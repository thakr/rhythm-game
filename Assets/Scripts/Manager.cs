using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public AudioClip song;
    public AudioSource audioSource;
    public float songBPM;
    public float manualMapOffset;
    public GameObject SongMap;

    private bool songPlaying = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && !songPlaying)
        {
            songPlaying = true;
            GameObject newSongMap = Instantiate(SongMap);
            newSongMap.transform.localPosition = Vector3.zero + new Vector3(0f, manualMapOffset, 0f);
            newSongMap.GetComponent<NoteScroller>().songBPM = songBPM / 60f * 2f ;
            newSongMap.GetComponent<NoteScroller>().startScroll();
            audioSource.clip = song;
            audioSource.Play();
        }
    }
}
