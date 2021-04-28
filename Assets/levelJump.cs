using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelJump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        if(PlayerPrefs.GetInt("level", PlayerPrefs.GetInt("level"))!=0&& PlayerPrefs.GetInt("level", PlayerPrefs.GetInt("level")) < 23)
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("level",0));
        }
        else if(PlayerPrefs.GetInt("level", PlayerPrefs.GetInt("level")) > 22)
        {
            SceneManager.LoadScene(23);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
