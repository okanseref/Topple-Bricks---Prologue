using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UI;
public class levelDuzenelyici : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] circles;
    [SerializeField] GameObject[] totallevels;
    [SerializeField] Sprite empty;
    [SerializeField] GameObject selection;
    public static int nextLevelFromMap = -2;
    void Start()
    {
        if (PlayerPrefs.GetInt("highlevel", 0) <= PlayerPrefs.GetInt("level", 0))
        {
            PlayerPrefs.SetInt("highlevel", PlayerPrefs.GetInt("level", 0));
        }
        nextLevelFromMap = -2;
        totallevels[0].GetComponent<TextMesh>().text = "LEVELS: " + (PlayerPrefs.GetInt("highlevel") + 1 + " / 171");
        totallevels[1].GetComponent<TextMesh>().text = "BALL SPENT: " + (PlayerPrefs.GetInt("ballCounter"));
        totallevels[2].GetComponent<TextMesh>().text = "PROGRESS: %" + (((float)PlayerPrefs.GetInt("highlevel") / (float)171)*100).ToString("0.0");
        totallevels[3].GetComponent<TextMesh>().text = "NEXT LEVEL: " + (PlayerPrefs.GetInt("highlevel", 0)+2);

        int i;
        for (i = 16; i > (PlayerPrefs.GetInt("highlevel", 0) + 1)/10 ; i--)
        {
            print("x");
            circles[i].transform.GetChild(0).gameObject.SetActive(false);
            circles[i].GetComponent<SpriteRenderer>().sprite=empty;
        }
        selection.transform.position = circles[i].transform.position;
  
        for (i=i ; i > -1; i--)
        {
            print("x2");

            int index = i;
            circles[i].AddComponent(typeof(Button));
            circles[i].GetComponent<Button>().onClick.AddListener(() => {
                nextLevelAdj(index);
            });
        }
    }
    public void nextLevelAdj( int i)
    {

        nextLevelFromMap = (i * 10)-1;
        selection.transform.position = circles[i].transform.position;
        totallevels[3].GetComponent<TextMesh>().text = "NEXT LEVEL: " + (1+(i * 10));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
