using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishNote : MonoBehaviour
{
    public Manager Manager;

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= 0f)
        {
            Manager.Finish();
        }
    }
}
