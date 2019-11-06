using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroShip : MonoBehaviour
{

    public AudioClip pew;
    public GameObject bullet;
    AudioSource audioSource;
    float x;
    float y;


    public float speed = 20.0f;
    float minX = -23.0f;
    float maxX = 23.0f;
    float minY = 4.0f;
    float maxY = 100.0f;
    void Start()
    {
        x = transform.position.x;
        y = transform.position.y;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        bool l = Input.GetKey(KeyCode.LeftArrow);
        bool r = Input.GetKey(KeyCode.RightArrow);
        bool u = Input.GetKey(KeyCode.UpArrow);
        bool d = Input.GetKey(KeyCode.DownArrow);
        float angleZ = transform.localEulerAngles.z;
        float h = Time.deltaTime * speed;
        float zh = Time.deltaTime * 50;
        float z = 0;

        if (l && !r)
        {
            x -= h;
            z += zh;
        }
        else if (!l && r)
        {
            x += h;
            z -= zh;
        }
        else if (angleZ != 0 && angleZ > 0 && angleZ <= 90)
        {
            z -= zh;
        }
        else if (angleZ != 0 && angleZ >= 270 && angleZ <= 360)
        {
            z += zh;
        }

        x = Mathf.Clamp(x, minX, maxX);

        if (d && !u)
        {
            y -= h;
        }
        else if (!d && u)
        {
            y += h;
        }

        y = Mathf.Clamp(y, minY, maxY);

        transform.Rotate(new Vector3(0, 0, z));

        transform.position = new Vector3(x, y, 0);

        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(pew);
            Instantiate(bullet, transform.position + new Vector3(0, 6, 0), transform.rotation);

        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col)
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
    }

}