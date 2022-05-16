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
        
        pointsPlus.GetComponent<TextMeshProUGUI>().text = "+" + points;
        pointsPlus.GetComponent<Animator>().SetTrigger("Show");

        this.points += points;

    }
    void resetText()
    {
        pointsPlus.GetComponent<TextMeshProUGUI>().text = "";
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time - prevTime > 5f)
        {
            this.prevTime = Time.time;
            pointsPlus.GetComponent<Animator>().SetTrigger("Hide");
            Invoke("resetText", 1);
        }
        scoreText.GetComponent<TextMeshProUGUI>().text = "Score: <b>" + this.points.ToString() + "</b>";
    }
}
