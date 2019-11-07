using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class level : MonoBehaviour {
    Text t;
    private static int l;
    // Start is called before the first frame update
    void Start () {
        t = GetComponent<Text> ();
        l = gameController.playerLevel;
        t.text = "Level :  " + l;
    }

    // Update is called once per frame
    void Update () {
        l = gameController.playerLevel;
        t.text = "Level :  " + l;
    }
}