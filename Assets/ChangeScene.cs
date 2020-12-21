using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public float time2skip;
    public int sceneNum;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(sc());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            FindObjectOfType<UIManager_Simple>().LoadSceneByNumber(sceneNum);
        }
    }

    IEnumerator sc()
    {
        yield return new WaitForSeconds(time2skip);
        FindObjectOfType<UIManager_Simple>().LoadSceneByNumber(sceneNum);
    }
}
