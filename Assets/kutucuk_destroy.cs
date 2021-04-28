using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kutucuk_destroy : MonoBehaviour
{
    public Sprite resim;
    public float maxHp = 15;
    float health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "oktagi" && collision.relativeVelocity.magnitude > 0)
        {
            health -= collision.relativeVelocity.magnitude;
            if (health <= 0)
            {
                Destroy(this.gameObject);
            }
            else if(health<maxHp*0.62f)
            {
                this.GetComponent<SpriteRenderer>().sprite = resim;
            }
            print("mag:" + collision.relativeVelocity.magnitude);
        }
    }
}
