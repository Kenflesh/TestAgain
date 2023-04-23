using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneLoad : MonoBehaviour
{
    public string SceneName;

    public void SceneLoad()
    {
        SceneManager.LoadScene(SceneName);
    }
}
