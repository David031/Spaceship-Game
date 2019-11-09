using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HeroShip : MonoBehaviour {
    AudioSource audioSource;
    public AudioClip pew;
    public GameObject bullet;
    public AudioClip hit;
    public GameObject hitEffect;
    float x;
    float y;
    public float speed = 20.0f;
    float minX = -30.0f;
    float maxX = 30.0f;
    float minY = 4.0f;
    float maxY = 100.0f;
    MeshRenderer render;
    void Start () {
        x = transform.position.x;
        y = transform.position.y;
        audioSource = GetComponent<AudioSource> ();
        render = gameObject.GetComponentInChildren<MeshRenderer> ();
        render.enabled = gameController.gameStart;
    }

    void Update () {
        render.enabled = gameController.gameStart;
        if (gameController.gameStart && !gameController.gameIsEnd) {
            bool l = Input.GetKey (KeyCode.LeftArrow);
            bool r = Input.GetKey (KeyCode.RightArrow);
            bool u = Input.GetKey (KeyCode.UpArrow);
            bool d = Input.GetKey (KeyCode.DownArrow);
            float angleZ = transform.localEulerAngles.z;
            float h = Time.deltaTime * speed;
            float zh = Time.deltaTime * 50;
            float z = 0;

            if (l && !r) {
                x -= h;
                z += zh;
            } else if (!l && r) {
                x += h;
                z -= zh;
            } else if (angleZ != 0 && angleZ > 0 && angleZ <= 90) {
                z -= zh;
            } else if (angleZ != 0 && angleZ >= 270 && angleZ <= 360) {
                z += zh;
            }

            x = Mathf.Clamp (x, minX, maxX);

            if (d && !u) {
                y -= h;
            } else if (!d && u) {
                y += h;
            }

            y = Mathf.Clamp (y, minY, maxY);

            transform.Rotate (new Vector3 (0, 0, z));

            transform.position = new Vector3 (x, y, 0);

            if (Input.GetButtonDown ("Fire1")) {
                audioSource.PlayOneShot (pew);
                switch (gameController.ammoNum) {
                    case 1:
                        Instantiate (bullet, transform.position + new Vector3 (0, 6, 0), transform.rotation);
                        break;
                    case 2:
                        Instantiate (bullet, transform.position + new Vector3 (-2, 3.5f, 0), transform.rotation);
                        Instantiate (bullet, transform.position + new Vector3 (2, 3.5f, 0), transform.rotation);
                        break;
                    case 3:
                        Instantiate (bullet, transform.position + new Vector3 (-3, 3.5f, 0), transform.rotation);
                        Instantiate (bullet, transform.position + new Vector3 (0, 6, 0), transform.rotation);
                        Instantiate (bullet, transform.position + new Vector3 (3, 3.5f, 0), transform.rotation);
                        break;
                    case 4:
                        Instantiate (bullet, transform.position + new Vector3 (-3.5f, 3.5f, 0), transform.rotation);
                        Instantiate (bullet, transform.position + new Vector3 (-1, 5, 0), transform.rotation);
                        Instantiate (bullet, transform.position + new Vector3 (1, 5, 0), transform.rotation);
                        Instantiate (bullet, transform.position + new Vector3 (3.5f, 3.5f, 0), transform.rotation);
                        break;
                }

            }

        }
        if (gameController.gameIsEnd) {
            Destroy (gameObject);
        }
    }
    private void OnTriggerEnter (Collider col) {
        if (col.tag == "BossBullet") {
            Instantiate (hitEffect, col.transform.position, transform.rotation);
            gameController.playerHP -= (int) (Random.Range (50f, 70f) * gameController.currentLevel * Random.Range (1f, 2f));
            audioSource.PlayOneShot (hit);
            Destroy (col.gameObject);
        } else if (col.tag == "Rocket") {
            Instantiate (hitEffect, col.transform.position, transform.rotation);
            gameController.playerHP -= (int) (Random.Range (40f, 60f) * gameController.currentLevel * Random.Range (1f, 2f));
            audioSource.PlayOneShot (hit);
            Destroy (col.gameObject);
        } else if (col.tag == "Minion") {
            Instantiate (hitEffect, col.transform.position, transform.rotation);
            audioSource.PlayOneShot (hit);
            gameController.playerHP -= (int) (Random.Range (50f, 70f) * gameController.currentLevel * Random.Range (1f, 2f));
        }
        if (gameController.playerHP <= 0) {
            gameController.isGameEnd (gameController.GameEndType.Lose);
            Destroy (gameObject);
        }
    }
}