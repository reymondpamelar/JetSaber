using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    private static ScoreManager instance;
    public static ScoreManager Instance { get { return instance; } }

    public int L;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameManager");
        if (go)
        {
            score = FindObjectOfType<GameManager>().score;
        }


        L = FindObjectOfType<UIManager_Simple>().L;

        if (L == 2 && score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", score);

        }
        if (L == 3 && score > PlayerPrefs.GetInt("HighScore2", 0))
        {
            PlayerPrefs.SetInt("HighScore2", score);

        }
        if (L == 4 && score > PlayerPrefs.GetInt("HighScore3", 0))
        {
            PlayerPrefs.SetInt("HighScore3", score);
        }
    }
}
