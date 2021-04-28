using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void asd()
    {
           Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "oktagi")
        {
            print("COLLLL");
            GetComponent<Animator>().SetBool("collision", true);
        }

    }
}
