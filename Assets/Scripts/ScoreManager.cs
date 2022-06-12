using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public GameObject pointsPlus;
    public GameObject scoreText;

    private int points = 0;
    // Start is called before the first frame update
    private float prevTime = 0f;
    public void updateScore(int points)
    {
        this.prevTime = Time.time;
        if (points > 80)
        {
            pointsPlus.GetComponent<TextMeshProUGUI>().text = "Perfect!\n+" + points;
        }
        else if (points > 60){
            pointsPlus.GetComponent<TextMeshProUGUI>().text = "Great!\n+" + points;
        }
        else if (points > 0)
        {
            pointsPlus.GetComponent<TextMeshProUGUI>().text = "Good!\n+" + points;
        }
        else
        {
            pointsPlus.GetComponent<TextMeshProUGUI>().text = "Missed!\n+" + points;
        }
        pointsPlus.GetComponent<Animator>().SetTrigger("Show");
        this.points += points;

    }
    public void resetPoints(bool disableText = false)
    {
        this.points = 0;
        if (disableText)
        {
            scoreText.SetActive(false);
        }
    }
    public void setPoints(int points)
    {
        this.points = points;
    }
    public int getPoints()
    {
        return this.points;
    }
    void resetText()
    {
        pointsPlus.GetComponent<TextMeshProUGUI>().text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - prevTime > 3f)
        {
            this.prevTime = Time.time;
            pointsPlus.GetComponent<Animator>().SetTrigger("Hide");
            Invoke("resetText", 1);
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: <b>" + this.points.ToString() + "</b>";
    }
}
