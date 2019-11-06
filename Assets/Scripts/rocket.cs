using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocket : MonoBehaviour
{
    void Start()
    {
        Rigidbody r = GetComponent<Rigidbody>();
        r.velocity = new Vector3(0, -100f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }
}
