using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class canvas_restart : MonoBehaviour
{
    [SerializeField] Sprite soundOn, soundOff;
    [SerializeField] GameObject soundObject;
    [SerializeField] GameObject[] menuItems;
    [SerializeField] Sprite[] menuSprites;
    bool menu = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("sound", 1) == 1)
        {
            soundObject.GetComponent<Image>().sprite = soundOn;
        }
        else
        {
            soundObject.GetComponent<Image>().sprite = soundOff;
        }
    }
    public void Restort()
    {
        //PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
        //SceneManager.LoadScene(PlayerPrefs.GetInt("level"));

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);   
    }
    public void SoundToggle()
    {
        if (PlayerPrefs.GetInt("sound", 1) == 1)
        {
            PlayerPrefs.SetInt("sound", 0);
            soundObject.GetComponent<Image>().sprite = soundOff;
        }
        else
        {
            PlayerPrefs.SetInt("sound", 1);
            soundObject.GetComponent<Image>().sprite = soundOn;
        }
    }
    public void SkipLevel()
    {
        PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level", 0)+1);
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
    public void proVersionLink()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.HonorApp.topplebrickspro");
    }
    public void continueButton()
    {
        if (levelDuzenelyici.nextLevelFromMap != -2)
        {
            if (levelDuzenelyici.nextLevelFromMap == -1)
            {
                PlayerPrefs.SetInt("level", levelDuzenelyici.nextLevelFromMap+1);
                SceneManager.LoadScene(levelDuzenelyici.nextLevelFromMap+1);
            }
            else
            {
                PlayerPrefs.SetInt("level", levelDuzenelyici.nextLevelFromMap);
                SceneManager.LoadScene(levelDuzenelyici.nextLevelFromMap);
            }
        }
        else
        {
            PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("highlevel"));

            SceneManager.LoadScene(PlayerPrefs.GetInt("highlevel"));
        }
    }
    public void menuWider()
    {
        if (menu == false)
        {
            menuItems[0].GetComponent<Image>().sprite = menuSprites[1];
            menuItems[1].SetActive(false);
            menuItems[2].SetActive(true);
            menuItems[3].SetActive(true);
            menuItems[4].SetActive(true);
            menu = true;
        }
        else
        {
            menuItems[0].GetComponent<Image>().sprite = menuSprites[0];
            menuItems[1].SetActive(true);
            menuItems[2].SetActive(false);
            menuItems[3].SetActive(false);
            menuItems[4].SetActive(false);
            menu = false;
        }
    }
    public void mapOpen()
    {
        SceneManager.LoadScene(24);
    }
}
