using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class okay_button : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject obje,codeObject;
    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("tutorial", 0) == 0)
        {
            codeObject.SetActive(false);
        }
        else
        {
            Destroy(obje);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Destroy(obje);
        codeObject.SetActive(true);
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
                    Destroy(obje);
                    codeObject.SetActive(true);
                    PlayerPrefs.SetInt("tutorial", 1);
                }
            }

        }

    }
}
