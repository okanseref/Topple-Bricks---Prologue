using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowcode : MonoBehaviour
{
    public Rigidbody2D rb;
    public int speed=100;
    [SerializeField] GameObject expoAnim;
    int expoPower = 550, damagePower = 15;

    public GameObject g;
    int health = 999;
    [SerializeField]bool isExpo;
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        Vector2 target = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        target.Normalize();
        speed = (int) code.power;
        code.power = 10;
        speed *= 8;
        rb.AddForce(target*speed);

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        Quaternion target2 = Quaternion.Euler(new Vector3(0,0,angle));

        this.gameObject.transform.rotation = target2;


    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isExpo)
        {
            if ((collision.gameObject.tag == "oktagi") && collision.relativeVelocity.magnitude * collision.gameObject.GetComponent<Rigidbody2D>().mass > 0)
            {
                boom();
            }
            if ((collision.gameObject.tag == "box" || collision.gameObject.tag == "structure" || collision.gameObject.tag == "barrel" || collision.gameObject.tag == "balontagi" || collision.gameObject.tag == "death") && collision.relativeVelocity.magnitude * collision.gameObject.GetComponent<Rigidbody2D>().mass > 0)
            {
                boom();
            }
        }
        else
        {
            if (collision.gameObject.tag == "block")
            {
                health--;
                rb.AddForce(new Vector2(transform.position.x, 0) * 10);
                if (health < 1)
                {
                    Destroy(this.gameObject);
                }
            }
        }


    }
    public void boom()
    {
        GameObject.FindObjectOfType<code>().boomSoundPlay();
        int rotate = Random.Range(-9, 9);
        push("box");
        List<GameObject> liste2 = new List<GameObject>(GameObject.FindGameObjectsWithTag("balontagi"));
        for (int i = 0; i < liste2.Count; i++)
        {
            if (Vector3.Distance(liste2[i].gameObject.transform.position, this.gameObject.transform.position) < 2.5f)
            {
                Vector2 temp = new Vector2((liste2[i].transform.position.x - gameObject.transform.position.x), (liste2[i].transform.position.y - gameObject.transform.position.y));

                float t = 1 / Mathf.Abs(temp.magnitude);
                temp.x *= t;
                temp.y *= t;

                liste2[i].GetComponent<labut>().takeDamage(temp.magnitude * damagePower);
                if (liste2[i] != null)
                {
                    liste2[i].GetComponent<Rigidbody2D>().AddForce(temp * expoPower);
                    liste2[i].GetComponent<Rigidbody2D>().AddTorque(rotate);
                }
            }
        }
        push("death");

        Instantiate(expoAnim, transform.position, transform.rotation);
        Destroy(this.gameObject);

    }
    public void push(string s)
    {
        int rotate = Random.Range(-9, 9);

        List<GameObject> liste = new List<GameObject>(GameObject.FindGameObjectsWithTag(s));
        for (int i = 0; i < liste.Count; i++)
        {
            Vector2 temp = new Vector2((liste[i].transform.position.x - gameObject.transform.position.x), (liste[i].transform.position.y - gameObject.transform.position.y));
            float t = 1 / Mathf.Abs(temp.magnitude);
            temp.x *= t;
            temp.y *= t;

            if (Vector3.Distance(liste[i].gameObject.transform.position, this.gameObject.transform.position) < 2.5f)
            {
                liste[i].GetComponent<Rigidbody2D>().AddForce(temp * expoPower);
                liste[i].GetComponent<Rigidbody2D>().AddTorque(rotate);

            }
        }
    }
}
