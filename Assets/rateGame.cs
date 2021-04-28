using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class rateGame : MonoBehaviour
{
    [SerializeField] GameObject obje, codeObject;
    // Start is called before the first frame update
    [SerializeField] bool type = false;
    void Start()
    {

        if (PlayerPrefs.GetInt("rate", 0) == 0)
        {
            codeObject.SetActive(false);
        }
        else
        {
            Destroy(obje);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject == this.gameObject)
                {
                    if (type == true)
                    {
                        Application.OpenURL("https://play.google.com/store/apps/details?id=com.HonorApp.oyun");
                        Destroy(obje);
                        codeObject.SetActive(true);
                    }
                    else
                    {
                        Destroy(obje);
                        codeObject.SetActive(true);
                        PlayerPrefs.SetInt("rate", 1);
                    }
                    PlayerPrefs.SetInt("rate", 1);

                }
            }

        }

    }
}
