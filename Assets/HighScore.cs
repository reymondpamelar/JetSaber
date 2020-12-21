using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TMP_Text score1;
    public TMP_Text score2;
    public TMP_Text score3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        score1.text = PlayerPrefs.GetInt("HighScore", 0).ToString();

        score2.text = PlayerPrefs.GetInt("HighScore2", 0).ToString();

        score3.text = PlayerPrefs.GetInt("HighScore3", 0).ToString();
    }
}
