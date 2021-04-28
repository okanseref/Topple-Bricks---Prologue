using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int select = Random.Range(0, 5);
        if(PlayerPrefs.GetInt("level", 0) == 19)
        {
            select = 100;
        }
        else
        {
            select = (PlayerPrefs.GetInt("level", 0)) % 6;

        }
        switch (select)
        {
            case 0:
                this.GetComponent<Camera>().backgroundColor = new Color(0.65f, 0.9379245f, 0.94581f);
                break;
            case 1:
                this.GetComponent<Camera>().backgroundColor = new Color(1f, 0.8479245f, 0.9477358f);
                break;
            case 2:
                this.GetComponent<Camera>().backgroundColor = new Color(0.662047f, 0.952047f, 0.8650355f);
                break;
            case 3:
                this.GetComponent<Camera>().backgroundColor = new Color(0.95f, 0.8454717f, 0.9177358f);
                break;
            case 4:
                this.GetComponent<Camera>().backgroundColor = new Color(0.9079245f, 0.9079245f, 1f);
                break;
            case 5:
                this.GetComponent<Camera>().backgroundColor = new Color(0.9679245f, 0.9679245f, 0.76f);
                break;
            case 100:
                this.GetComponent<Camera>().backgroundColor = new Color(1f, 0.5879245f, 0.61f);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
