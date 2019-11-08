using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class gameController : MonoBehaviour {
    public GameObject minion;
    public GameObject boss;
    GameObject ammo1;
    GameObject ammo2;
    GameObject ammo3;
    GameObject ammo4;
    GameObject healthBar;
    GameObject startUI;
    GameObject gameEnd;
    public static bool gameIsEnd;
    public static bool gameStart;
    public static int ammoNum;
    public static string gameEndText;
    public static int currentLevel;
    public static int playerHP;
    public static int playerHPTotal;
    public static int score;
    public static int playerLevel;
    public static int playerXP;
    public static int playerXPTotal;
    public static int ad;
    float timerO;
    float timerM;
    int bossCount;
    int count;
    bool genMinionNoOrder;
    public static bool bossIsGen;

    void Start () {
        bossIsGen = false;
        gameIsEnd = false;
        gameStart = false;
        ammoNum = 1;
        gameEndText = "";
        currentLevel = 1;
        playerHP = 100;
        playerHPTotal = 100;
        score = 0;
        playerLevel = 1;
        playerXP = 0;
        playerXPTotal = 100;
        ad = 35;
        timerO = 0f;
        timerM = 0f;
        bossCount = 0;
        count = 0;
        genMinionNoOrder = true;
        ammo1 = GameObject.Find ("UI/ammo1");
        ammo2 = GameObject.Find ("UI/ammo2");
        ammo3 = GameObject.Find ("UI/ammo3");
        ammo4 = GameObject.Find ("UI/ammo4");
        healthBar = GameObject.Find ("UI/bossHealthBar");
        healthBar.GetComponent<Image> ().enabled = false;
        gameEnd = GameObject.Find ("GameEnd");
        gameEnd.GetComponent<Canvas> ().enabled = gameIsEnd;
        startUI = GameObject.Find ("Start");
        startUI.GetComponent<Canvas> ().enabled = !gameStart;
    }
    public void RestartGame () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }
    public void gameIsStart (bool b) {
        gameStart = b;
    }
    void genMinionWithOrder (float delay, int callCount) {
        float speed = 15;
        timerO += Time.deltaTime;
        if (delay < 1) {
            Debug.Log ("Value Error");
            return;
        } else if (timerO > delay && count <= callCount) {
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
        if (timerM > timerd && canGen) {
            GameObject obj = Instantiate (minion, transform.position + new Vector3 (Random.Range (-30.0f, 5.0f), -20, 0), Quaternion.Euler (90f, 0f, 180f));
            obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -speed, 0);
            timerM = 0;
        }
    }
    void genBoss () {
        bossIsGen = true;
        GameObject obj = Instantiate (boss, transform.position + new Vector3 (0, 0, 0), Quaternion.Euler (90f, 0f, 180f));
        obj.GetComponent<Rigidbody> ().velocity = new Vector3 (0, -10, 0);
    }
    public enum GameEndType {
        Win,
        Lose,
    }
    public static void isGameEnd (GameEndType type) {
        gameIsEnd = true;
        switch (type) {
            case GameEndType.Win:
                gameEndText = "Mission Complete ~ ~ ~ ";
                Debug.Log ("Win");
                break;
            case GameEndType.Lose:
                gameEndText = "Mission Fail ~ ~ ~ ";
                Debug.Log ("Lose");
                break;
        }
    }
    void FixedUpdate () {
        if (playerXP > playerXPTotal) {
            playerLevel += 1;
            playerXP = 0;
            playerXPTotal += (int) (playerXPTotal * 1.2);
            ad += playerLevel * 5;
            playerHP += (int) (playerHPTotal * 1.2);
            playerHPTotal += (int) (playerHPTotal * 1.2);
            if (playerLevel == 8) {
                ammoNum = 2;
            } else if (playerLevel == 13) {
                ammoNum = 3;
            } else if (playerLevel == 15) {
                ammoNum = 4;
            }
        }
        if (score < 8000) {
            currentLevel = 2;
        } else if (score < 12000) {
            count = 0;
            currentLevel = 4;
        } else if (score < 20000) {
            count = 0;
            currentLevel = 6;
        } else if (score < 30000 && score > 25000) {
            count = 0;
            currentLevel = 7;
        } else if (score > 35000) {
            currentLevel = 8;
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
        }
    }
    void Update () {
        gameEnd.GetComponent<Canvas> ().enabled = gameIsEnd;
        startUI.GetComponent<Canvas> ().enabled = !gameStart;
        Debug.Log ("1" + gameStart);
        Debug.Log (gameIsEnd);
        if (gameStart && !gameIsEnd) {
            Debug.Log ("current level " + currentLevel);
            Debug.Log ("Count" + count);
            if (currentLevel == 8 && bossCount < 1) {
                Debug.Log ("Level 5");
                genBoss ();
                bossCount = 1;
            } else if (bossCount != 1) {
                genMinionWithOrder (15, currentLevel * 2 - 1);
                genMinion (genMinionNoOrder);
            }
        }

    }
}