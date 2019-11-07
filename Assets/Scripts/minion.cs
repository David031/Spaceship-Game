using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minion : MonoBehaviour {
    public GameObject bullet;
    int hp;
    float timeri = 0f;
    void Start () {
        hp = gameController.currentLevel * 100;
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
        if (col.gameObject.tag == "bullet") {
            Destroy(col.gameObject);
            hp -= gameController.ad;
        } else if (col.gameObject.tag == "heroShip") {
            hp -= gameController.ad * 2;
        }else if (col.gameObject.tag == "Minion") {
            Destroy(col.gameObject);
        }
        if (hp <= 0) {
            gameController.playerXP += (int) (Random.Range (50f, 80f) * gameController.currentLevel * Random.Range (1f, 2f));
            gameController.score += (int) (Random.Range (100f, 200f) * gameController.currentLevel * Random.Range (1f, 2f));
            Destroy (gameObject);
        }
    }
}