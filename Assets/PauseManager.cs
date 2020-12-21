using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public static bool paused;

    public GameObject pauseUI;

    public Button ResumeButton;
    public Button MainMenuButton;

    void Start()
    {
        ResumeButton.GetComponent<Button>();
        ResumeButton.onClick.AddListener(() => Resume());
        MainMenuButton.GetComponent<Button>();
        MainMenuButton.onClick.AddListener(() => LoadMenu());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

    void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        paused = false;
        StartCoroutine(FindObjectOfType<UIManager_Simple>().SceneTransition(0));
        GameManager.instance.firstPlay = false;
    }
}
