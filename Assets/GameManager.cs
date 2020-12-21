using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using TMPro;
using Debug = UnityEngine.Debug;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public AudioSource Music;
    public bool play;
    public bool firstPlay;
    public static GameManager instance;

    public int score;
    public int scorePerNote = 100;
    public TMP_Text sText;

    public int multiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;
    public TMP_Text mText;

    public float time2StartMusic;

    private GameObject P;
    private PlayerManager pm;

    bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        play = false;
        firstPlay = false;
        FindObjectOfType<ScoreManager>().score = 0;
        score = 0;
        instance = this;
        sText.text = "0";
        multiplier = 1;
        mText.text = "x" + multiplier;

        P = GameObject.Find("Ryzer");
        pm = P.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!play && !firstPlay)
        {
            play = true;
            StartCoroutine(PlayMusic());
        }
        if (PauseManager.paused)
        {
            if (play)
            {
                Music.Pause();
                play = false;
            }
            else
            {
            }
        }
        else
        {
            if (!play && firstPlay)
            {
                play = true;
                Music.Play();
            }
        }
    }

    IEnumerator PlayMusic()
    {
        yield return new WaitForSeconds(time2StartMusic);
        firstPlay = true;
        Music.Play();
    }

    public void NoteHit()
    {
        Debug.Log("Hit on Time");

        if(multiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[multiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                multiplier++;
            }
        }
        mText.text = "x" + multiplier;
        score += scorePerNote * multiplier;
        sText.text = "" + score;
        if(pm.PlayerHealth < 1f)
        {
            pm.PlayerHealth += 0.05f;
        }
    }

    public void NoteMissed()
    {
        Debug.Log("Missed Note");
        StartCoroutine(pm.damaged());
        multiplier = 1;
        multiplierTracker = 1;
        mText.text = "x" + multiplier;

        pm.PlayerHealth -= 0.1f;
    }

    public void EndGame()
    {
        if(gameEnded == false)
        {
            gameEnded = true;
            Debug.Log("GameOver");
            showGameOver();
        }
    }

    void showGameOver()
    {
        StartCoroutine(FindObjectOfType<UIManager_Simple>().SceneTransition(5));
    }
}
