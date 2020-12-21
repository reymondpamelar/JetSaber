using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamage : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject P = GameObject.Find("Ryzer");
            PlayerManager pm = P.GetComponent<PlayerManager>();
            pm.PlayerHealth -= 0.003f;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
