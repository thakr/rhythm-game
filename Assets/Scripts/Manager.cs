using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager : MonoBehaviour
{
    public AudioClip song;
    public AudioSource audioSource;
    public float songBPM;
    public float manualMapOffset;
    public GameObject SongMap;
    public GameObject ScoreManager;
    public GameObject CountdownTimer;

    private bool songPlaying = false;
    // Update is called once per frame

   
    void Update()
    {
        if (Input.anyKeyDown && !songPlaying)
        {
            songPlaying = true;
            GameObject newSongMap = Instantiate(SongMap);
            Note[] notes = newSongMap.GetComponentsInChildren<Note>();
            foreach (Note n in notes)
            {
                n.scoreManager = ScoreManager;
            }
            newSongMap.transform.localPosition = Vector3.zero + new Vector3(0f, manualMapOffset, 0f);
            newSongMap.GetComponent<NoteScroller>().songBPM = songBPM / 60f * 2f ;
            audioSource.clip = song;

            StartCoroutine(Countdown(newSongMap));
            
        }
    }

    IEnumerator Countdown(GameObject newSongMap)
    {
        int timerLength = 3; //secs
        for (int i = timerLength; i >= 0; i--)
        {
            CountdownTimer.GetComponent<TextMeshProUGUI>().text = i.ToString();
            yield return new WaitForSeconds(1);

            if (i == 0)
            {
                newSongMap.GetComponent<NoteScroller>().startScroll();
                audioSource.Play();
                CountdownTimer.GetComponent<TextMeshProUGUI>().text = "";
                yield break;
            }
        }
        
    }
}
