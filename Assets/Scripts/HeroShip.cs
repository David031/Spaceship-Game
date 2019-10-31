using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShip : MonoBehaviour {

    public AudioClip pew;
    public GameObject bullet;
    AudioSource audioSource;
    float x;
    float y;
    public float speed = 20.0f;
    float minX = -23.0f;
    float maxX = 23.0f;
    float minY = 4.0f;
    float maxY = 35.0f;
    void Start () {
        x = transform.position.x;
        y = transform.position.y;
        audioSource = GetComponent<AudioSource> ();
    }

    void Update () {
        bool l = Input.GetKey (KeyCode.LeftArrow); // left arrow
        bool r = Input.GetKey (KeyCode.RightArrow);
        bool u = Input.GetKey (KeyCode.UpArrow); // left arrow
        bool d = Input.GetKey (KeyCode.DownArrow); // right arrow
        float h = Time.deltaTime * speed;
        if (l && !r) x -= h;
        else if (!l && r) x += h;
        x = Mathf.Clamp (x, minX, maxX);
        if (d && !u) y -= h;
        else if (!d && u) y += h;
        y = Mathf.Clamp (y, minY, maxY); // x is clamped
        transform.position = new Vector3 (x, y, 0); // Set global position
        if (Input.GetButtonDown ("Fire1")) {
            audioSource.PlayOneShot (pew);
            Instantiate (bullet, transform.position + new Vector3 (0, 3, 0), transform.rotation);
            
        }
    }
}