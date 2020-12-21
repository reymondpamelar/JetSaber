using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform Player;
    public Transform fpUp;
    public Transform fpDown;
    public Transform fpRight;
    public Transform fpLeft;
    public GameObject laser;

    public Transform upHB;
    public Transform downHB;
    public Transform rightHB;
    public Transform leftHB;

    float speed = 50f;

    public GameObject slash;

    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            StartCoroutine(shootUp());
        }
        if (Input.GetKeyDown("down"))
        {
            StartCoroutine(shootDown());
        }
        if (Input.GetKeyDown("right"))
        {
            StartCoroutine(shootRight());
        }
        if (Input.GetKeyDown("left"))
        {
            StartCoroutine(shootLeft());
        }
    }

    IEnumerator shootUp()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(Player.position, Player.up);

        if (hitInfo)
        {
            var clone = Instantiate(laser, fpRight.position, Quaternion.Euler(0f, 180f, 180f));
            Vector3 originalPos = clone.transform.position;
            while (clone.transform.position != upHB.position)
            {
                Vector3 newPos = Vector3.MoveTowards(clone.transform.position, upHB.position, speed * Time.deltaTime);
                clone.transform.position = newPos;

                GameObject HB = GameObject.Find("Up HitBox");
                Laser L = HB.GetComponent<Laser>();
                if (clone.transform.position == upHB.position && L.canBePressed)
                {
                    var slashClone = Instantiate(slash, upHB.position, Quaternion.Euler(0f, 180f, 180f));
                    slashClone.transform.parent = upHB.transform;
                    Vector3 moveDirection = clone.transform.position - originalPos;
                    if (moveDirection != Vector3.zero)
                    {
                        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                        slashClone.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    }
                    Destroy(slashClone, 2f);
                }

                yield return null;
            }

            Destroy(clone, 0.1f);

        }
    }

    IEnumerator shootDown()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(Player.position, -Player.up);

        if (hitInfo)
        {
            var clone = Instantiate(laser, fpRight.position, Quaternion.Euler(0f, 180f, 180f));
            Vector3 originalPos = clone.transform.position;
            while (clone.transform.position != downHB.position)
            {
                Vector3 newPos = Vector3.MoveTowards(clone.transform.position, downHB.position, speed * Time.deltaTime);
                clone.transform.position = newPos;


                GameObject HB = GameObject.Find("Down HitBox");
                Laser L = HB.GetComponent<Laser>();
                if (clone.transform.position == downHB.position && L.canBePressed)
                {
                    var slashClone = Instantiate(slash, downHB.position, Quaternion.Euler(0f, 180f, 180f));
                    slashClone.transform.parent = downHB.transform;
                    Vector3 moveDirection = clone.transform.position - originalPos ;
                    if (moveDirection != Vector3.zero)
                    {
                        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                        slashClone.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    }
                    Destroy(slashClone, 2f);
                }

                yield return null;
            }
            Destroy(clone, 0.1f);

        }
    }

    IEnumerator shootRight()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(Player.position, Player.right);

        if (hitInfo)
        {
            var clone = Instantiate(laser, fpRight.position, Quaternion.Euler(0f, 180f, 180f));
            Vector3 originalPos = clone.transform.position;
            while (clone.transform.position != rightHB.position)
            {
                Vector3 newPos = Vector3.MoveTowards(clone.transform.position, rightHB.position, speed * Time.deltaTime);
                clone.transform.position = newPos;

                GameObject HB = GameObject.Find("Right HitBox");
                Laser L = HB.GetComponent<Laser>();
                if (clone.transform.position == rightHB.position && L.canBePressed)
                {
                    var slashClone = Instantiate(slash, rightHB.position, Quaternion.Euler(0f, 180f, 180f));
                    slashClone.transform.parent = rightHB.transform;
                    Vector3 moveDirection = clone.transform.position - originalPos;
                    if (moveDirection != Vector3.zero)
                    {
                        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                        slashClone.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    }
                    Destroy(slashClone, 2f);
                }

                yield return null;
            }
            Destroy(clone, 0.1f);

        }
    }

    IEnumerator shootLeft()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(Player.position, -Player.right);

        if (hitInfo)
        {
            var clone = Instantiate(laser, fpRight.position, Quaternion.Euler(0f, 180f, 180f));
            Vector3 originalPos = clone.transform.position;
            while (clone.transform.position != leftHB.position)
            {
                Vector3 newPos = Vector3.MoveTowards(clone.transform.position, leftHB.position, speed * Time.deltaTime);
                clone.transform.position = newPos;

                GameObject HB = GameObject.Find("Left HitBox");
                Laser L = HB.GetComponent<Laser>();
                if (clone.transform.position == leftHB.position && L.canBePressed)
                {
                    var slashClone = Instantiate(slash, leftHB.position, Quaternion.Euler(0f, 180f, 180f));
                    slashClone.transform.parent = leftHB.transform;
                    Vector3 moveDirection = clone.transform.position - originalPos;
                    if (moveDirection != Vector3.zero)
                    {
                        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
                        slashClone.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                    }
                    Destroy(slashClone, 2f);
                }

                yield return null;
            }
            Destroy(clone, 0.1f);

        }
    }
}
