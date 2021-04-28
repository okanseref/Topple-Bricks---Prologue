using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject buton,text;
    void Start()
    {
        if (PlayerPrefs.GetInt("Skipped", 0) == 1)
        {
            buton.SetActive(false);
        }
    }
    public void NotLoadedYet()
    {
        text.GetComponent<TextMesh>().text = "AD NOT LOADED YET, TRY AGAIN";
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
