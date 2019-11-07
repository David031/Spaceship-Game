using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion : MonoBehaviour {
    public GameObject bullet;

    float timeri = 0f;
    void Start () {

    }
    void Update () {
        timeri += Time.deltaTime;
        if (timeri > 0.99f) {
            Instantiate (bullet, transform.position + new Vector3 (4, -6, 0), transform.rotation * Quaternion.Euler (0f, 180f, 0f));
            Instantiate (bullet, transform.position + new Vector3 (-4, -6, 0), transform.rotation * Quaternion.Euler (0f, 180f, 0f));
        }
        if (timeri > 1f) {
            timeri = 0;
        }
        if (transform.position.y < -20) {
            Destroy (gameObject);
        }
    }
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.tag == "bullet" || col.gameObject.tag == "heroShip") {
            Debug.Log (col.gameObject.tag);
            Destroy (col.gameObject);
            Destroy (gameObject);
        }
    }
}