using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private Transform hitTransform;
    private bool canHit = false;
    public GameObject hitObject;
    public GameObject scoreManager;
    public GameObject explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hit")
        {
            hitTransform = collision.transform;
            canHit = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Hit")
        {
            canHit = false;
            hitTransform = null;
            if (gameObject.activeSelf)
            {
                scoreManager.GetComponent<ScoreManager>().updateScore(0);
            }

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(hitObject.GetComponent<HitObject>().key))
        {
            if (canHit)
            {
                HitAudioPlayer.playHitSound();
                int score = Math.Max(0, 100 - (int) (Math.Abs(gameObject.transform.parent.localPosition.y + gameObject.transform.localPosition.y - hitTransform.transform.parent.localPosition.y) * 100));
                scoreManager.GetComponent<ScoreManager>().updateScore(score);
                gameObject.SetActive(false);
                GameObject explosionObj = Instantiate(explosion);
                explosionObj.transform.position = gameObject.transform.position;
                Destroy(gameObject);
            }
        }
        
    }
}
