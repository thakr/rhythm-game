using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAudioPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameObject instance;
    public static AudioClip audioClip;

    private void Start()
    {
        instance = gameObject;
        audioClip = gameObject.GetComponent<AudioSource>().clip;
    }
    public static void playHitSound()
    {
        //instance.GetComponent<AudioSource>().PlayOneShot(audioClip, 1f);
        instance.GetComponent<AudioSource>().Play();
    }
}
