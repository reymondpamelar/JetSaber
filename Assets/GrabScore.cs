using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GrabScore : MonoBehaviour
{
    private GameObject s;
    private ScoreManager sm;
    public int score;
    public TMP_Text sText;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        sText.text = "0";
        s = GameObject.Find("Player Score");
        sm = s.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        score = sm.score;
        sText.text = "" + score;
    }
}
