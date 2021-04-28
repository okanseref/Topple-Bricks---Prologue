using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class code : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] sounds;

    public int multiplier = 1;
    public Rigidbody2D rb;
    public GameObject arrow;
    public static float power = 10;
    int maxPower = 124,skipCounter=0;
    [SerializeField] GameObject[] list;
    Color renk = new Color(255, 255, 255, 100);
    Vector4 renkvek;
    bool k = false,timerActive=false;
    float time = 0,powerAcc=5f;
    List<GameObject> labuts;
    void Start()
    {
        power = 10;
        rb = GetComponent<Rigidbody2D>();
        renkvek = new Vector4(255, 255, 255, 255);
        labuts = GameObject.FindGameObjectsWithTag("balontagi").ToList();

    }

    void Update()
    {


        if (k)
        {
            int sira = (int)Mathf.Round(power / (maxPower / list.Length));
            sira=Mathf.Clamp(sira,0, list.Length-1);
            power = Mathf.Clamp(power, 0, maxPower-1);
            //renk.a = (((float)power % ((float)maxPower / list.Length)))/(float) ((float)maxPower / list.Length);
            renk.a = 1;
            list[sira].GetComponent<SpriteRenderer>().color = renk;
            if (power < maxPower)
            {
                if (maxPower * 0.5f > power)
                {
                    power += powerAcc;
                }
                else
                {
                    power += powerAcc*2;
                }
            }
            
        }
        if (Input.GetMouseButtonDown(0)&& !IsPointerOverUIObject())
        {
            print("y" + list.Length);

            k = true;
        }
        if (Input.GetMouseButtonUp(0) && rotategun.valid && k==true)
        {
            print("x"+list.Length);
            int select = Random.Range(0, 4);
            audioSource.PlayOneShot(sounds[select],(((float)power/maxPower)*0.5f) * PlayerPrefs.GetInt("sound", 1));
            Instantiate(arrow, transform.position, transform.rotation);
            PlayerPrefs.SetInt("ballCounter", PlayerPrefs.GetInt("ballCounter",0)+1);
            k = false;
            renk.a = 0;
            foreach (var item in list)
            {
                item.GetComponent<SpriteRenderer>().color = renk;
            }

            if (power > maxPower / 2)
            {
                skipCounter++;
            }

            if (skipCounter > 60)
            {
                GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(6).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(7).gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(8).gameObject.SetActive(true);
            }
        }
        if (timerActive)
        {
            time += Time.deltaTime;
            if (time > 2f)
            {
                if (PlayerPrefs.HasKey("level"))
                {
                    PlayerPrefs.SetInt("level", PlayerPrefs.GetInt("level") + 1);
                    timerActive = false;
                    //if (PlayerPrefs.GetInt("level") > 16)
                    //{
                    //    PlayerPrefs.SetInt("level", 1);
                    //}
                }
                else
                {
                    PlayerPrefs.SetInt("level", 1);
                    timerActive = false;
                }
                GameObject.FindGameObjectWithTag("Finish").GetComponent<reklam>().ShowAds();
            }
        }
    }
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    public void RemoveLabut(GameObject lbt)
    {
        Destroy(lbt);
        labuts.Remove(lbt);

        //burda bekleme olması lzm
        if (labuts.Count == 0 || !labuts.Any())
        {
            timerActive = true;
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(2).gameObject.GetComponent<Button>().interactable = false;
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(4).gameObject.SetActive(true);
            GameObject.FindGameObjectWithTag("Canvas").transform.GetChild(4).gameObject.transform.GetChild(1).GetComponent<Text>().text = "NEXT LEVEL: " + (PlayerPrefs.GetInt("level") + 2);



        }
    }
    public void boomSoundPlay()
    {
        audioSource.PlayOneShot(sounds[4], 0.9f*PlayerPrefs.GetInt("sound",1));
    }
    public void deathSoundPlay()
    {
        audioSource.PlayOneShot(sounds[5], 0.2f * PlayerPrefs.GetInt("sound", 1));
    }
}
