﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lzaer_bullet : MonoBehaviour
{
	void Start () {
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = new Vector3(0, 100.0f, 0);  // Global y-axis. Speed = 100.0f
    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y > 120)
        {
            Destroy(gameObject);
        }
    }
}
