using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg2 : MonoBehaviour {
    float y;
    float x;
    public float speed = 2.0f;
    public GameObject heroShip;
    // Start is called before the first frame update
    void Start () {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        y -= speed * Time.deltaTime;
        if (y < -150.0f) {
            y = 200.0f;
        }
        x = -0.33f * heroShip.transform.position.x;
        transform.position = new Vector3 (x, y, transform.position.z);

    }
}