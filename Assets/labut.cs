using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class labut : MonoBehaviour
{

    public float maxHealth=20;
    public float health;
    public GameObject death,healthbar;
    float tt;
    bool blockDamage = true,bugDupDeathFix=true;
    public Rigidbody2D rb;
    [SerializeField] Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        refreshHpBar();
        int x = Random.Range(0, 3);
        switch (x)
        {
            case 0:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
                break;
            case 1:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
                break;
            case 2:
                gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (blockDamage)
        {
            tt += Time.deltaTime;
            if (tt > 1f)
            {
                blockDamage = false;
            }
        }

    }
    void refreshHpBar()
    {
        healthbar.transform.localScale = new Vector3((health / maxHealth), 1f, -1f);
        if ((float)health / (float)maxHealth > 0.8f)
        {
            healthbar.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
        }
        else if((float)health / (float)maxHealth > 0.5f)
        {
            healthbar.GetComponent<SpriteRenderer>().color = new Color(227, 255, 0);
        }
        else
        {
            healthbar.GetComponent<SpriteRenderer>().color = new Color(255, 0, 0);
        }
        if (health <= 0)
        {
            if (bugDupDeathFix)
            {
                Instantiate(death, transform.position, transform.rotation);
                bugDupDeathFix = false;
                GameObject.FindObjectOfType<code>().deathSoundPlay();

                GameObject.FindObjectOfType<code>().RemoveLabut(this.gameObject);
            }


        }
    }
    public void takeDamage(float damage)
    {
        health -= damage;
        refreshHpBar();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!blockDamage)
        {
            if ((collision.gameObject.tag == "structure" || collision.gameObject.tag == "box") && collision.relativeVelocity.magnitude * collision.gameObject.GetComponent<Rigidbody2D>().mass > 0)
            {
                takeDamage((collision.relativeVelocity.magnitude * collision.gameObject.GetComponent<Rigidbody2D>().mass));
            }
            if (collision.gameObject.tag == "oktagi" && collision.relativeVelocity.magnitude > 0)
            {
                takeDamage(collision.relativeVelocity.magnitude);
            }
        }

    }

}
