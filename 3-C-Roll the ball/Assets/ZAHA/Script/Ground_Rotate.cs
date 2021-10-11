using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground_Rotate : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        transform.Rotate(new Vector3(Vertical * speed, 0,  Horizontal * speed));

        if(gameObject.transform.localEulerAngles.x >= 30.0f)
        {
            transform.Rotate(new Vector3(30, 0,0));
        }
        if (gameObject.transform.localEulerAngles.z >= 30.0f)
        {
            transform.Rotate(new Vector3(0, 0, 30));
        }

    }
}
