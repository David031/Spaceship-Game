using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class healthbar : MonoBehaviour {
    // Start is called before the first frame update
    Image bar;

    void Start () {
        bar = GetComponent<Image> ();
        bar.fillAmount = (float) gameController.playerHP / (float) gameController.playerHPTotal;
    }

    // Update is called once per frame
    void Update () {
        
        bar.fillAmount = (float) gameController.playerHP / (float) gameController.playerHPTotal;
        Debug.Log (bar.fillAmount);
    }
}