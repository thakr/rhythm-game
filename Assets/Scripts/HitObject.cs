using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitObject : MonoBehaviour
{
    public KeyCode key;
    public TextMeshPro text;
    public Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        text.text = key.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            anim.Play();
        }
    }
}
