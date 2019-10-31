using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour {

    public GameObject explosion;

    void OnCollisionEnter(Collision col) {
        if (col.gameObject.tag == "bullet") {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }
}



