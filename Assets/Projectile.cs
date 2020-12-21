using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1f;
    public Rigidbody2D rb;
    void Start()
    {
        if(Input.GetKeyDown("up")){
            rb.velocity = transform.up * speed;
        }
        if (Input.GetKeyDown("down")){
            rb.velocity = -transform.up * speed;
        }
        if (Input.GetKeyDown("right")){
            rb.velocity = transform.right * speed;
        }
        if (Input.GetKeyDown("left")){
            rb.velocity = -transform.right * speed;
        }
    }


}
