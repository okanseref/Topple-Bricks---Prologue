using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaplan : MonoBehaviour
{
    public float targetTime = 60.0f;
    bool end = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            if (end == false)
            {
                timerEnded();
                end = true;
            }
           
        }

        void timerEnded()
        {
            print("over.");

        }
    }
}
