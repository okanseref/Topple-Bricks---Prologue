using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatearrow : MonoBehaviour
{
    public GameObject gun;
    bool k = false;
    float scalex=0.2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {        
        if (Input.GetMouseButtonDown(0))
        {
            k = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            k = false;
            scalex = 0.2f;
        }

        if (k)
        {
            if (scalex < 1)
            {
                scalex += 0.05f;
            }
            
           
            GetComponent<Renderer>().enabled = true;
            transform.localScale =new Vector3(scalex,1f,0);
        }
        else
        {
            GetComponent<Renderer>().enabled = false;
        }

    }
}
