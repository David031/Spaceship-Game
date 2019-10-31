using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg1 : MonoBehaviour
{
    float y;
    float x;
    public float speed = 2.0f;
    public GameObject heroShip;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        y -= speed * Time.deltaTime;
        if (y < -150.0f)
        {
            y = 200.0f;
        }
        x = -0.33f * heroShip.transform.position.x;
        transform.position = new Vector3(x, y, transform.position.z);
        /// <summary>
        /// OnCollisionEnter is called when this collider/rigidbody has begun
        /// touching another rigidbody/collider.
        /// </summary>
        /// <param name="other">The Collision data associated with this collision.</param>
        void OnCollisionEnter(Collision other)
        {
            
        }
    }
}