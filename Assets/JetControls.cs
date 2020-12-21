using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetControls: MonoBehaviour
{
    private float jetForce = 50.0f;
    private Rigidbody2D playerRigidbody;
    public float forwardMovementSpeed = 3.0f;

    void FixedUpdate()
    {
        bool jetpackActive = Input.GetKey("space");
        if (jetpackActive)
        {
            playerRigidbody.AddForce(new Vector2(0, jetForce));
        }
        Vector2 newVelocity = playerRigidbody.velocity;
        newVelocity.x = forwardMovementSpeed;
        playerRigidbody.velocity = newVelocity;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
