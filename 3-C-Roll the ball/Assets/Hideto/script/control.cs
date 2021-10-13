using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;
    private float speed;
    private int Hflag;
    private int Vflag;
    private float Hspeed;
    private float Vspeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 0.1f;
        Hflag = 0;
        Vflag = 0;
        Hspeed = 0;
        Vspeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        if (Horizontal > 0)
        {
            Hflag = 1;
            Hspeed += 0.01f;
        } else if (Horizontal < 0)
        {
            Hspeed -= 0.01f;

        }
        else
        {
            Hflag = 0;
            Hspeed = 0;
        }
        if (Vertical > 0)
        {
            Vflag = 1;
            Vspeed += 0.01f;
        }
        else if (Vertical < 0)
        {
            Vspeed -= 0.01f;
        }
        else
        {
            Vflag = 0;
            Vspeed = 0;
        }
    

        transform.localPosition += (new Vector3(Hspeed * speed, 0,Vspeed * speed));


        //if (gameObject.transform.localPosition.x >= 30.0f)
        //{
        //    transform.localPosition.x += (new Vector3(30, 0, 0));
        //}
        //if (gameObject.transform.localPosition.z >= 30.0f)
        //{
        //    transform.localPosition = (new Vector3(0, 0, 30));
        //}

    }
}
