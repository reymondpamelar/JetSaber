using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMo : MonoBehaviour
{
    public GameObject sm;
    public AudioSource Music;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (sm.activeSelf)
        {
            Debug.Log("active");
            Time.timeScale = 0.5f;
            Music.pitch = Time.timeScale;
        }
        else
        {
            Time.timeScale = 1f;
            Music.pitch = Time.timeScale;
        }
    }
}
