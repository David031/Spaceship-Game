using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gameController : MonoBehaviour {
    public GameObject minion;
    public GameObject boss;
    GameObject ammo1;
    GameObject ammo2;
    GameObject ammo3;
    GameObject ammo4;

    public static bool isGameEnd;
    public static int ammoNum = 1;
    float timerO = 0f;
    float timerM = 0f;
    public static int currentLevel = 1;
    public static int playerHP = 100;
    public static int playerHPTotal = 100;
    public static int score = 0;
    public static int playerLevel = 1;
    public static int playerXP = 0;
    public static int playerXPTotal = 100;
    int count = 0;
    bool genMinionNoOrder = true;
    public static int ad = 35;

    void Start () {
        isGameEnd = false;
        ammo1 = GameObject.Find ("UI/ammo1");
        ammo2 = GameObject.Find ("UI/ammo2");
        ammo3 = GameObject.Find ("UI/ammo3");
        ammo4 = GameObject.Find ("UI/ammo4");
    }

    void genMinionWithOrder (float delay, int callCount) {
        float speed = 15;
        timerO += Time.deltaTime;
        if (delay == null || delay < 1) {
            Debug.Log ("Value Error");
            return;
        } else if (timerO > (delay - 1f + 0.9999f) && count <= callCount) {
            genMinionNoOrder = false;
            for (int i = 0; i < 4; i++) {
                GameObject obj = Instantiate (minion, transform.position + new Vector3 (-30 + i * 20, i * 20, 0), Quaternion.Euler (90f, 0f, 180f));
                obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -speed, 0);
            }
            for (int i = 3; i > 0; i--) {
                GameObject obj = Instantiate (minion, transform.position + new Vector3 (30 - i * 20, i * 20 + 60, 0), Quaternion.Euler (90f, 0f, 180f));
                obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -speed, 0);
            }
            count += 1;
        }
        if (timerO > delay) {
            timerO = 0;
            if (count > callCount) {
                genMinionNoOrder = true;

            }
        }
    }
    void genMinion (bool canGen) {
        int speed = 15;
        int timerd = 2;

        if (currentLevel > 3) {
            speed = 30;
            timerd = 1;
        }
        timerM += Time.deltaTime;
        if (timerM > (timerd + 0.9999f) && canGen) {
            GameObject obj = Instantiate (minion, transform.position + new Vector3 (Random.Range (-30.0f, 5.0f), -20, 0), Quaternion.Euler (90f, 0f, 180f));
            obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -speed, 0);
        }
        if (timerM > timerd + 1) {
            timerM = 0;
        }
    }
    void genBoss () {
        GameObject obj = Instantiate (boss, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (90f, 0f, 180f));
        obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -10, 0);
    }
    void FixedUpdate () {
        if (isGameEnd) {
            Time.timeScale = 0;
            Debug.Log ("END");
        }
        if (playerXP > playerXPTotal) {
            playerLevel += 1;
            playerXP = 0;
            playerXPTotal += (int) (playerXPTotal * 1.3);
            ad += playerLevel * 5;
            playerHP += (int) (playerHPTotal * 1.3);
            playerHPTotal += (int) (playerHPTotal * 1.3);
            if (playerLevel == 8) {
                ammoNum = 2;
            } else if (playerLevel == 13) {
                ammoNum = 3;
            } else if (playerLevel == 17) {
                ammoNum = 4;
            }
        }
        if (score < 1001) {
            currentLevel = 1;
        } else if (score < 2001) {
            currentLevel = 2;
        } else if (score < 5001) {
            count = 0;
            currentLevel = 3;
        } else if (score < 10001) {
            count = 0;
            currentLevel = 4;
        } else if (score < 20001) {
            currentLevel = 5;
        }
        switch (ammoNum) {
            case 1:
                ammo1.GetComponent<Image> ().enabled = true;
                ammo2.GetComponent<Image> ().enabled = false;
                ammo3.GetComponent<Image> ().enabled = false;
                ammo4.GetComponent<Image> ().enabled = false;
                break;
            case 2:
                ammo1.GetComponent<Image> ().enabled = true;
                ammo2.GetComponent<Image> ().enabled = true;
                ammo3.GetComponent<Image> ().enabled = false;
                ammo4.GetComponent<Image> ().enabled = false;
                break;
            case 3:
                ammo1.GetComponent<Image> ().enabled = true;
                ammo2.GetComponent<Image> ().enabled = true;
                ammo3.GetComponent<Image> ().enabled = true;
                ammo4.GetComponent<Image> ().enabled = false;
                break;
            case 4:
                ammo1.GetComponent<Image> ().enabled = true;
                ammo2.GetComponent<Image> ().enabled = true;
                ammo3.GetComponent<Image> ().enabled = true;
                ammo4.GetComponent<Image> ().enabled = true;
                break;
            default:
                ammo1.GetComponent<Image> ().enabled = true;
                ammo2.GetComponent<Image> ().enabled = false;
                ammo3.GetComponent<Image> ().enabled = false;
                ammo4.GetComponent<Image> ().enabled = false;
                break;
        }
    }
    void Update () {
        Debug.Log ("current level " + currentLevel);
        Debug.Log ("Count" + count);
        if (currentLevel == 5) {
            Debug.Log ("Level 5");
            genBoss ();
            currentLevel = 6;
        } else {
            genMinionWithOrder (15, currentLevel * 2 - 1);
            genMinion (genMinionNoOrder);
        }

    }
}