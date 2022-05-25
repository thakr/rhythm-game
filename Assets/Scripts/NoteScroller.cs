using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    private bool hasStarted = false;


    public float songBPM;
    public string songName;

    // Start is called before the first frame update
    void Start()
    {
    }
    public void startScroll ()
    {
        hasStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        { 
            transform.position -= new Vector3(0f, songBPM * Time.deltaTime);
        }
    }
}
