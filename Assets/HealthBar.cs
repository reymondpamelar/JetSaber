using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private GameObject P;
    private PlayerManager pm;

    Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        P = GameObject.Find("Ryzer");
        pm = P.GetComponent<PlayerManager>();
        localScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (pm.PlayerHealth >= -0.1)
        {
            localScale.x = pm.PlayerHealth;
            transform.localScale = localScale;
        }
    }
}
