using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expo_anim : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void animMid()
    {
        List<GameObject> liste3 = new List<GameObject>(GameObject.FindGameObjectsWithTag("barrel"));
        liste3.Remove(this.gameObject);
        print(liste3.Count);
        for (int i = 0; i < liste3.Count; i++)
        {
            if (Vector3.Distance(liste3[i].gameObject.transform.position, this.gameObject.transform.position) < 2.5f)
            {
                liste3[i].GetComponent<explode>().boom();
            }
        }
    }
    public void animEnd()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
