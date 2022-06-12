using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAgain : MonoBehaviour
{
    public GameObject OverScreen;
    public Manager manager;
    // Start is called before the first frame update
    public void ButtonPress()
    {
        OverScreen.SetActive(false);
        manager.setAbleToPlay(true);
    }
}
