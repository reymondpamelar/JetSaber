using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class BeatScrollerLVL1 : MonoBehaviour
{
    private float beatTempo = 98;
    // Start is called before the first frame update
    void Start()
    {
        beatTempo = beatTempo / 60f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(beatTempo * Time.deltaTime, 0f, 0f);

    }
}
