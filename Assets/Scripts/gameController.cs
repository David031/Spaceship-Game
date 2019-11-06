using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour
{
    public GameObject minion;
    void Start()
    {
        genMinion();

    }

    void genMinion()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject obj = Instantiate(minion, transform.position + new Vector3(-30 + i * 20, i * 20, 0), Quaternion.Euler(90f, 0f, 180f));
            obj.GetComponent<Rigidbody>().velocity = new Vector3(0, -30f, 0);
        }
    }

    void Update()
    {

    }
}
