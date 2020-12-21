using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMode : MonoBehaviour
{
    public bool createMode;
    public GameObject n;
    public KeyCode keyToPress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(keyToPress))
            {
                GameObject newObject = Instantiate(n, transform.position, Quaternion.identity);
                newObject.GetComponent<NoteObject>().keyToPress = keyToPress;
            }
        }
    }
}
