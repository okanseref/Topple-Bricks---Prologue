using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotategun : MonoBehaviour
{
    Vector2 target;
    float angle;
    public static bool valid = false;
    //[SerializeField] int angle1=-360, angle2=360;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        target = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        target.Normalize();
        angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        angle -= 90;
        if (angle > -360 && angle < 360)
        {
            valid = true;
            Quaternion target2 = Quaternion.Euler(new Vector3(0, 0, angle));
    
            this.gameObject.transform.rotation = target2;
        }
        else{
            valid = false;
        }
        
    }
}
