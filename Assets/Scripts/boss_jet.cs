using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_jet : MonoBehaviour {
    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {
        if (transform.position.y <= 83) {
            transform.position = new Vector3 (0, 83, 0);
        }
    }
    void OnCollisionEnter (Collision col) {
        Destroy (col.gameObject);
    }
}