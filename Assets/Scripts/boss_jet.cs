using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class boss_jet : MonoBehaviour {
    // Start is called before the first frame update
    public static int hp = 100000;
    public GameObject expolEffect;
    public GameObject hitEffect;
    public AudioClip hit;
    public GameObject bullet;
    public GameObject rocket;

    GameObject healthBar;
    AudioSource audioSource;
    float speed = 30;
    float timer = 0;
    float timerb = 0;
    float timerr = 0;
    int count = 1;
    void Start () {
        healthBar = GameObject.Find ("UI/bossHealthBar");
        healthBar.GetComponent<Image> ().enabled = true;
        audioSource = GetComponent<AudioSource> ();
    }
    // Update is called once per frame
    void Update () {
        if (transform.position.y <= 83) {
            transform.position = new Vector3 (0, 83, 0);
        }
        timer += Time.deltaTime;
        timerb += Time.deltaTime;
        timerr += Time.deltaTime;
        genBullet ();
        genRocket ();
        Debug.Log (count);
        if (gameController.gameIsEnd) {
            Destroy (gameObject);
        }
    }
    void genBullet () {
        if (timerb > 1.0) {
            GameObject obj1 = Instantiate (bullet, transform.position + new Vector3 (2.95f, -11f, 0), Quaternion.Euler (-90f, 0f, 0f));
            obj1.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -40, 0);
            GameObject obj2 = Instantiate (bullet, transform.position + new Vector3 (-2.95f, -11f, 0), Quaternion.Euler (-90f, 0f, 0f));
            obj2.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -40, 0);
            timerb = 0;
        }
    }
    void genRocket () {
        if ((timerr > 2.0 && count == 1) || (timerr > 3.0 && count == 2) || (timerr > 4.0 && count == 3) || (timerr > 5.0 && count == 4) || (timerr > 6.0 && count == 5)) {
            GameObject obj1 = Instantiate (rocket, transform.position + new Vector3 (25 - count * 3, 0, 0), Quaternion.Euler (-90f, 0f, 0f));
            obj1.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -speed, 0);
            GameObject obj2 = Instantiate (rocket, transform.position + new Vector3 (-25 + count * 3, 0, 0), Quaternion.Euler (-90f, 0f, 0f));
            obj2.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -speed, 0);
            count += 1;
        }
        if (count > 5) {
            count = 1;
            timerr = 0;
        }
    }
    void OnCollisionEnter (Collision col) {
        audioSource.PlayOneShot (hit);
        gameController.playerXP += 50;
        Instantiate (hitEffect, col.transform.position, transform.rotation);
        Destroy (col.gameObject);
        hp -= gameController.ad;
        if (hp <= 0) {
            Instantiate (expolEffect, transform.position, transform.rotation);
            gameController.isGameEnd (gameController.GameEndType.Win);
            Destroy (gameObject);
        }
    }
}