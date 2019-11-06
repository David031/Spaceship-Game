using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion : MonoBehaviour
{
    public GameObject bullet;
    void Start()
    {
        Invoke("rocketGo", 2);
    }
    void rocketGo()
    {
        Instantiate(bullet, transform.position + new Vector3(4, -6, 0), transform.rotation * Quaternion.Euler(0f, 180f, 0f));
        Instantiate(bullet, transform.position + new Vector3(-4, -6, 0), transform.rotation * Quaternion.Euler(0f, 180f, 0f));

    }
    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "bullet")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}
