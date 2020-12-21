using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public GameObject WarningSign1;
    public GameObject WarningSign2;
    public GameObject WarningSign3;

    public GameObject laser1;
    public GameObject laser2;
    public GameObject laser3;

    public bool up;
    public bool down;
    public bool right;
    public bool left;
    public bool canBePressed;
    private GameObject GM;
    private GameManager g;

    // Start is called before the first frame update
    void Start()
    {
        WarningSign1.SetActive(false);
        WarningSign2.SetActive(false);
        WarningSign3.SetActive(false);
        laser1.SetActive(false);
        laser2.SetActive(false);
        laser3.SetActive(false);

        GM = GameObject.Find("GameManager");
        g = GM.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up") && up && !canBePressed)
        {
            g.NoteMissed();
        }
        if (Input.GetKeyDown("down") && down && !canBePressed)
        {
            g.NoteMissed();
        }
        if (Input.GetKeyDown("right") && right && !canBePressed)
        {
            g.NoteMissed();
        }
        if (Input.GetKeyDown("left") && left && !canBePressed)
        {
            g.NoteMissed();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Untagged")
        {
            canBePressed = true;
        }


        if (other.tag == "activateLaser1")
        {
            canBePressed = true;
            StartCoroutine(activeLaser1());
        }


        if (other.tag == "activateLaser2")
        {
            canBePressed = true;
            StartCoroutine(activeLaser2());
        }


        if (other.tag == "activateLaser3")
        {
            canBePressed = true;
            StartCoroutine(activeLaser3());
        }

        if (other.tag == "endGame")
        {
            canBePressed = true;
            StartCoroutine(showGameOver());
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Untagged" || other.tag == "activateLaser1" || other.tag == "activateLaser2" || other.tag == "activateLaser3" || other.tag == "endGame")
        {
            canBePressed = false;
        }
    }

    IEnumerator activeLaser1()
    {
        WarningSign1.SetActive(true);
        yield return new WaitForSeconds(3f);
        WarningSign1.SetActive(false);

        var clone = Instantiate(laser1, laser1.transform.position, laser1.transform.rotation);
        clone.transform.parent = laser1.transform.parent;
        clone.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        clone.SetActive(false);
    }


    IEnumerator activeLaser2()
    {
        WarningSign2.SetActive(true);
        yield return new WaitForSeconds(3f);
        WarningSign2.SetActive(false);

        var clone = Instantiate(laser2, laser2.transform.position, laser2.transform.rotation);
        clone.transform.parent = laser2.transform.parent;
        clone.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        clone.SetActive(false);
    }

    IEnumerator activeLaser3()
    {
        WarningSign3.SetActive(true);
        yield return new WaitForSeconds(3f);
        WarningSign3.SetActive(false);

        var clone = Instantiate(laser3, laser3.transform.position, laser3.transform.rotation);
        clone.transform.parent = laser3.transform.parent;
        clone.SetActive(true);
        yield return new WaitForSeconds(3.5f);
        clone.SetActive(false);
    }

    IEnumerator showGameOver()
    {
        yield return new WaitForSeconds(3f);
        StartCoroutine(FindObjectOfType<UIManager_Simple>().SceneTransition(5));
    }

}
