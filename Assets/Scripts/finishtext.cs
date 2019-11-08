using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class finishtext : MonoBehaviour {
    Text t;
    private static string s;
    // Start is called before the first frame update
    void Start () {
        t = GetComponent<Text> ();
        s = gameController.gameEndText;
        t.text = s;
    }

    // Update is called once per frame
    void Update () {
        s = gameController.gameEndText;
        t.text = s;
    }
}