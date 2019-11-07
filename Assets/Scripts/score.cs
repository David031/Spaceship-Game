using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {
    Text t;
    private static int s;
    // Start is called before the first frame update
    void Start () {
        t = GetComponent<Text> ();
        s = gameController.score;
        t.text = "Score :  " + s;
    }

    // Update is called once per frame
    void Update () {
        s = gameController.score;
        t.text = "Score :  " + s;
    }
}