using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public AudioClip song;
    public AudioSource audioSource;
    public float manualMapOffset;
    public GameObject SongMap;
    public GameObject ScoreManager;
    public GameObject CountdownTimer;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI completeText;
    public Image ScoreFill;
    public GameObject GameOverScreen;
    public GameObject ScoreTextMain;
    public bool songPlaying = false;
    private bool ableToPlay;

    public void Finish()
    {
        songPlaying = false;
        StartCoroutine(AudioHelper.FadeOut(audioSource, 1f));
        Destroy(GameObject.FindGameObjectWithTag("GameMap"));
        int points = ScoreManager.GetComponent<ScoreManager>().getPoints();
        
        scoreText.text = points.ToString();
        int totalPossiblePoints = GameObject.FindGameObjectWithTag("GameMap").transform.childCount * 100;
        string songName = GameObject.FindGameObjectWithTag("GameMap").GetComponent<NoteScroller>().songName;
        ScoreFill.fillAmount = (float) points / totalPossiblePoints;
        completeText.text = "You completed <b>" + songName + "</b> with a score of:";
        GameOverScreen.SetActive(true);

    }
    private void Start()
    {
        ableToPlay = true;
    }
    public void setAbleToPlay(bool val)
    {
        ableToPlay = val;
    }
    void Update()
    {
        if (Input.anyKeyDown && ableToPlay && !songPlaying)
        {
            ableToPlay = false;
            songPlaying = true;
            ScoreTextMain.SetActive(true);
            GameObject newSongMap = Instantiate(SongMap);
            Note[] notes = newSongMap.GetComponentsInChildren<Note>();
            FinishNote finish = newSongMap.GetComponentInChildren<FinishNote>();
            finish.Manager = this;
            foreach (Note n in notes)
            {
                n.scoreManager = ScoreManager;
            }
            newSongMap.transform.localPosition = Vector3.zero + new Vector3(0f, manualMapOffset, 0f);
            newSongMap.GetComponent<NoteScroller>().songBPM = newSongMap.GetComponent<NoteScroller>().songBPM / 60f * 2f ;
            audioSource.clip = song;
            audioSource.time = 0f;
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
                ScoreTextMain.SetActive(true);
                yield break;
            }
        }
        
    }
}
