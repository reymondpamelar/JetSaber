using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float PlayerHealth = 1;
    public AudioSource dmg;
    public SpriteRenderer s;

    private Animator myAnimator;

    private bool slashRight;


    // Start is called before the first frame update
    void Start()
    {
        dmg = GetComponent<AudioSource>();
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        endGame();
    }

    void FixedUpdate()
    {
        HandleAttacks();
        ResetValues();

    }

    

    public IEnumerator damaged()
    {
        dmg.Play(0);
        s.color = new Color(1f, 1f, 1f, .4f);
        yield return new WaitForSeconds(0.5f);
        s.color = new Color(1f, 1f, 1f, 1f);
    }

    private void HandleAttacks()
    {
        if (slashRight)
        {
            myAnimator.SetTrigger("Slash Right");
        }
    }


    private void HandleInput()
    {
        if (Input.GetKeyDown("up") || Input.GetKeyDown("left") || Input.GetKeyDown("right") || Input.GetKeyDown("down"))
        {
            slashRight = true;
        }
    }

    private void ResetValues()
    {
        slashRight = false;
    }

    private void endGame()
    {
        if(PlayerHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
