using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        // Scene切换
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}
