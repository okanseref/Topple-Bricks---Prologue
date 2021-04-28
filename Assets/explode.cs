using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explode : MonoBehaviour
{
    // Start is called before the first frame update
    int expoPower = 550,damagePower=15;
    public GameObject expoAnim;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void push(string s)
    {
        int rotate = Random.Range(-9, 9);

        List<GameObject> liste = new List<GameObject>(GameObject.FindGameObjectsWithTag(s));
        for (int i = 0; i < liste.Count; i++)
        {
            Vector2 temp = new Vector2((liste[i].transform.position.x - gameObject.transform.position.x), (liste[i].transform.position.y - gameObject.transform.position.y));
            float t = 1/Mathf.Abs(temp.magnitude);
            temp.x *=  t;
            temp.y *=  t;

            if (Vector3.Distance(liste[i].gameObject.transform.position, this.gameObject.transform.position) < 2.5f)
            {
                liste[i].GetComponent<Rigidbody2D>().AddForce(temp * expoPower);
                liste[i].GetComponent<Rigidbody2D>().AddTorque(rotate);

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
                Vector2 temp = new Vector2((liste2[i].transform.position.x - gameObject.transform.position.x)  , (liste2[i].transform.position.y  - gameObject.transform.position.y) );
                float t = 1 / Mathf.Abs(temp.magnitude);
                temp.x *= t;
                temp.y *= t;

                liste2[i].GetComponent<labut>().takeDamage( temp.magnitude*damagePower);
                if (liste2[i] != null) {
                    liste2[i].GetComponent<Rigidbody2D>().AddForce(temp * expoPower);
                    liste2[i].GetComponent<Rigidbody2D>().AddTorque(rotate);
                }
            }
        }
        push("death");

        Instantiate(expoAnim,transform.position,transform.rotation);
        Destroy(this.gameObject);

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if ((collision.gameObject.tag == "oktagi") && collision.relativeVelocity.magnitude * collision.gameObject.GetComponent<Rigidbody2D>().mass > 6)
        {
            Destroy(collision.gameObject);
            boom();           
        }
        if ((collision.gameObject.tag == "box"|| collision.gameObject.tag == "structure"|| collision.gameObject.tag == "barrel"|| collision.gameObject.tag == "labut") && collision.relativeVelocity.magnitude * collision.gameObject.GetComponent<Rigidbody2D>().mass > 10)
        {
            boom();
        }
    }
}
