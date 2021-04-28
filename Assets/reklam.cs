using System.Collections;
using System.Collections.Generic;
using UnityEngine.Advertisements;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reklam : MonoBehaviour , IUnityAdsListener
{
    // Start is called before the first frame update
    string gameId = "3703959";
    bool testMode = true;
    int ad = 0;
    int reklamRate = 100;
    void Start()
    {
        if (PlayerPrefs.GetInt("level", 0) > 27)
        {
            reklamRate = 5;
        }

        ad = PlayerPrefs.GetInt("ads",0);
        if (PlayerPrefs.GetInt("level", 0) == 21)
        {
            ad = 6; //RATE SAYFASI OLAN LEVELDA REKLAM ÇIKMASIN DİYE
        }
        print("ad:" + ad);
        if (ad >= reklamRate)
        {
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }


    }
    public void ShowAds()
    {
        ad++;
        PlayerPrefs.SetInt("ads", ad);
        if (ad >= reklamRate*5f&& !Advertisement.IsReady())
        {
            SceneManager.LoadScene("WatchAd");
        }
        else if (ad >= reklamRate && Advertisement.IsReady())
        {
            Advertisement.Show();
            PlayerPrefs.SetInt("ads", 0);
        }
        else
        {
            print(PlayerPrefs.GetInt("level", 0) % 10 == 9);
            if (PlayerPrefs.GetInt("level",0) % 10 == 9)
            {
                SceneManager.LoadScene("Map");
            }
            else
            {
                SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
            }
        }
    }
    public void ForceShowAd()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, testMode);
        if (Advertisement.IsReady())
        {
            Advertisement.Show();
            PlayerPrefs.SetInt("ads", 0);
        }
        else
        {
            GameObject.FindObjectOfType<SkipControl>().NotLoadedYet();
        }

    }
    public void SkipForNow()
    {
        PlayerPrefs.SetInt("ads", reklamRate*3);
        PlayerPrefs.SetInt("Skipped", 0);// SINIRSIZ SKIP HAKKI VAR ,,, 1 YAPARSAN 1 HAKKI OLUR
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("level"));
    }
    void Update()
    {
       
    }

    public void OnUnityAdsReady(string placementId)
    {
    }

    public void OnUnityAdsDidError(string message)
    {
    }

    public void OnUnityAdsDidStart(string placementId)
    {
    }
}
