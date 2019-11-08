using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class bossHealthBar : MonoBehaviour {
    Image bar;

    void Start () {
        bar = GetComponent<Image> ();
        Debug.Log(boss_jet.hp);
        bar.fillAmount = (float) boss_jet.hp / (float) 100000;
    }

    // Update is called once per frame
    void Update () {
        bar.fillAmount = (float) boss_jet.hp / (float) 100000;
    }
}