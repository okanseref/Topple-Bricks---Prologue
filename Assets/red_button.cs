using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class red_button : MonoBehaviour
{
    public Sprite pushed;
    public Sprite stand;
    bool x = true,locked=false;
    float timer = 0;

    red_stone[] redStones;
    // Start is called before the first frame update
    void Start()
    {
        redStones = FindObjectsOfType<red_stone>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer > 2.4f)
        {
            timer = 0;
            locked = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!locked&&(collision.gameObject.tag == "oktagi"||collision.gameObject.tag=="box") && collision.relativeVelocity.magnitude > 1)
        {
            if (x)
            {
                x = false;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = pushed;
                this.gameObject.GetComponent<PolygonCollider2D>().offset = new Vector2(0, 0);

                foreach (var item in redStones)
                {
                    item.gameObject.SetActive(false);
                }
                
            }
            else
            {
                x = true;
                this.gameObject.GetComponent<SpriteRenderer>().sprite = stand;
                this.gameObject.GetComponent<PolygonCollider2D>().offset = new Vector2(0,0.12f);

                foreach (var item in redStones)
                {
                    item.gameObject.SetActive(true);
                }
            }
            locked = true;
        }
    }
}
