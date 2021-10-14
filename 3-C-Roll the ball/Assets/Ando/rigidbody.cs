using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rigidbody : MonoBehaviour
{
    Rigidbody rd;

    void Start()
    {
        rd = this.GetComponent<Rigidbody>();
        rd.useGravity = true;
    }
}