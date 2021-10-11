using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    private float Horizontal;
    private float Vertical;
    // Start is called before the first frame update
    void Start()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Horizontal);
        Debug.Log(Vertical);
    }
}
