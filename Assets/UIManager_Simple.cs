using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager_Simple : MonoBehaviour
{
    //Referenced from S. Price
    public static UIManager_Simple Instance { get; private set; }

    public UIManager_Simple _ui_manager;
    public List<GameObject> prefabsToInst;
    private List<GameObject> uiCanvases;
    private Dictionary<string, GameObject> uiDictionary;
    public Button playgameButton;
    public Button HighScoresButton;
    public Button aboutButton;
    public Button RestartButton;
    public Button MainMenuButton;
    public Button quitButton;
    public Button Level1Button;
    public Button Level2Button;
    public Button Level3Button;
    private string myActiveScene = "MainMenu";

    public int L = 0;

    public Animator transition;
    public Animator LevelTransition;
    public GameObject lst;

    public void Awake()
    {
        if (Instance == null)
        {
            uiCanvases = new List<GameObject>();
            uiDictionary = new Dictionary<string, GameObject>();

            Instance = this;
            DontDestroyOnLoad(this);

            myActiveScene = SceneManager.GetActiveScene().name;


            foreach (GameObject prefab in prefabsToInst)
            {
                GameObject toAdd = Instantiate(prefab);
                toAdd.name = prefab.name;
                toAdd.transform.SetParent(transform);
                Debug.Log("Adding " + toAdd.name.ToString() + "to list");
                uiCanvases.Add(toAdd);
                uiDictionary.Add(toAdd.name.ToString(), toAdd);
            }

            if (myActiveScene == "MainMenu")
            {
                foreach (GameObject canvasgo in uiCanvases)
                {
                    canvasgo.SetActive(false);
                }
                GameObject go = uiDictionary["Canvas_Main"];
                go.SetActive(true);
                playgameButton = GameObject.FindGameObjectWithTag("playgameButton").GetComponent<Button>();
                playgameButton.onClick.AddListener(() => StartCoroutine(SceneTransition(6)));

                HighScoresButton = GameObject.FindGameObjectWithTag("HighScoresButton").GetComponent<Button>();
                HighScoresButton.onClick.AddListener(() => StartCoroutine(SceneTransition(7)));

                aboutButton = GameObject.FindGameObjectWithTag("aboutButton").GetComponent<Button>();
                aboutButton.onClick.AddListener(() => StartCoroutine(SceneTransition(8)));

                quitButton = GameObject.FindGameObjectWithTag("quitButton").GetComponent<Button>();
                quitButton.onClick.AddListener(() => StartCoroutine(QuitGame()));

                myActiveScene = "MainMenu";

            }

        }
        else
        {
            Destroy(gameObject); //kill all other versions of this gameObject
        }
    }
    public IEnumerator SceneTransition(int sNum)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1.5f);
        LoadSceneByNumber(sNum);
        transition.SetTrigger("End");
    }

    public IEnumerator LevelSceneTransition(int sNum)
    {
        lst.SetActive(true);
        LevelTransition.SetTrigger("Start");
        yield return new WaitForSeconds(5f);
        LoadSceneByNumber(sNum);
        LevelTransition.SetTrigger("End");
    }

    IEnumerator QuitGame()
    {
        yield return new WaitForSeconds(1f);
        Quit();
    }

    //Loads scene based on number in scene list
    public void LoadSceneByNumber(int SceneNumber)
    {
        SceneManager.LoadScene(SceneNumber);
    }

    //Referenced from S. Price
    void OnLevelWasLoaded(int level)
    {
        if (uiDictionary == null) return;
        UnityEngine.Debug.Log("On Level was loaded with level = " + level + " ...");

        if (level == 0)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(true);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);
            go = uiDictionary["Canvas_HighScores"];
            go.SetActive(false);

        }

        if (level == 1)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(true);
            Level1Button = GameObject.FindGameObjectWithTag("Level1Button").GetComponent<Button>();
            Level1Button.onClick.AddListener(() => StartCoroutine(LevelSceneTransition(2)));
            Level2Button = GameObject.FindGameObjectWithTag("Level2Button").GetComponent<Button>();
            Level2Button.onClick.AddListener(() => StartCoroutine(LevelSceneTransition(3)));
            Level3Button = GameObject.FindGameObjectWithTag("Level3Button").GetComponent<Button>();
            Level3Button.onClick.AddListener(() => StartCoroutine(LevelSceneTransition(4)));
            MainMenuButton = GameObject.FindGameObjectWithTag("MainMenuButton").GetComponent<Button>();
            MainMenuButton.onClick.AddListener(() => StartCoroutine(SceneTransition(0)));
        }

        if (level == 2)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);
            L = 2;
        }
        if (level == 3)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);
            L = 3;
        }
        if (level == 4)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);
            L = 4;
        }
        if (level == 5)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(true);
            MainMenuButton = GameObject.FindGameObjectWithTag("MainMenuButton").GetComponent<Button>();
            MainMenuButton.onClick.AddListener(() => StartCoroutine(SceneTransition(0)));
            RestartButton = GameObject.FindGameObjectWithTag("RestartButton").GetComponent<Button>();
            RestartButton.onClick.AddListener(() => StartCoroutine(SceneTransition(L)));
        }
        if (level == 6)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);
        }
        if (level == 7)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);
            go = uiDictionary["Canvas_HighScores"];
            go.SetActive(true);
            MainMenuButton = GameObject.FindGameObjectWithTag("MainMenuButton").GetComponent<Button>();
            MainMenuButton.onClick.AddListener(() => StartCoroutine(SceneTransition(0)));
        }
        if (level == 8)
        {
            GameObject go = uiDictionary["Canvas_Main"];
            go.SetActive(false);
            go = uiDictionary["Canvas_PlayGame"];
            go.SetActive(false);
            go = uiDictionary["Canvas_GameOver"];
            go.SetActive(false);
            go = uiDictionary["Canvas_HighScores"];
            go.SetActive(false);
        }
    }

    //Quit Button
    public void Quit()
    {
        Debug.Log("Game Exited.");

#if     UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //set the PlayMode to stop
#else
        Application.Quit();
#endif
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
