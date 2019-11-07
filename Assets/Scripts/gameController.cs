using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
    public GameObject minion;
    float timeri = 0f;
    int currentLevel = 1;
    
    void Start () {

    }

    void genMinionWithOrder () {
        for (int i = 0; i < 4; i++) {
            GameObject obj = Instantiate (minion, transform.position + new Vector3 (-30 + i * 20, i * 20, 0), Quaternion.Euler (90f, 0f, 180f));
            obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -30f, 0);
        }
    }
    void genMinion () {
        timeri += Time.deltaTime;
        if (timeri > 1.9999f) {
            GameObject obj = Instantiate (minion, transform.position + new Vector3 (Random.Range (-30.0f, 30.0f), 20, 0), Quaternion.Euler (90f, 0f, 180f));
            obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -30f, 0);
        }
        if (timeri > 2f) {
            timeri = 0;
        }
    }

    void Update () {
        genMinion ();
    }
}