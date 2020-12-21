using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode keyToPress;

    private bool obtained = false;

    private Animator myAnimator;
    private bool explode;

    public Transform Player;
    float speed = 30f;


    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            if (canBePressed)
            {
                GameManager.instance.NoteHit();
                explode = true;
                obtained = true;
                StartCoroutine(destroyNote());
            }
        }
    }

    IEnumerator destroyNote()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (explode)
        {
            myAnimator.SetTrigger("Explode");
        }
        ResetValues();
    }

    private void ResetValues()
    {
        explode = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            if (!obtained)
            {
                GameManager.instance.NoteMissed();
            }
            StartCoroutine(attackPlayer());
        }
    }

    IEnumerator attackPlayer()
    {
        while (transform.position != Player.position)
        {
            Vector3 newPos = Vector3.MoveTowards(transform.position, Player.position, speed * Time.deltaTime);
            transform.position = newPos;

            if(transform.position == Player.position)
            {
                Destroy(gameObject);
            }
            yield return null;
        }
    }
}
