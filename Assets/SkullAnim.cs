using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkullAnim : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Sprite x1, x2, x3;
    float time = 0;
    public float mul = 0.1f;
    bool bugfix = true;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (bugfix==true)
        {
            this.gameObject.transform.GetChild(1).GetComponent<Text>().text = "NEXT LEVEL: " + (PlayerPrefs.GetInt("level") + 2+" / 24");
            bugfix = false;
        }
        time += Time.deltaTime;
        if (time < 1*mul)
        {
            this.gameObject.GetComponent<Image>().sprite = x1;
        }else if (time < 2 * mul)
        {
            this.gameObject.GetComponent<Image>().sprite = x2;
        }
        else if(time < 3 * mul)
        {
            this.gameObject.GetComponent<Image>().sprite = x3;
        }
        else
        {
            time = 0;
        }

    }
}
