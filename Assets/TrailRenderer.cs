using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using UnityEngine;

public class TrailRenderer : MonoBehaviour
{
    //private TrailRenderer tr; void Start() { tr = GetComponent(); }
    public float trailTimeout;

    IEnumerator stopTrail() {
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right") )
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
            yield return new WaitForSeconds(trailTimeout);
            gameObject.GetComponent<ParticleSystem>().Play();
        }
    }

    void Update()
    {
        StartCoroutine(stopTrail());
    }


}
