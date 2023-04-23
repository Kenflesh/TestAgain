using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Esc : MonoBehaviour
{
    public string SceneName;

    void Update()
    {
        if (SceneName == "")
            Application.Quit();
        else if (Input.GetKey(KeyCode.Escape))
            SceneManager.LoadScene(SceneName);
    }
}
