using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Result : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI result;
    [SerializeField] TextMeshProUGUI timeTextMesh;

    private void Start()
    {
        result.SetText($"{TestScript.CorrectAnswers}|{TestScript.CountQuestions}");

        var time = System.TimeSpan.FromSeconds(TestScript.time);

        if (time.Hours > 0)
            timeTextMesh.SetText($"{time.Hours}�:{time.Minutes}�:{time.Seconds}�");
        else if (time.Minutes > 0)
            timeTextMesh.SetText($"{time.Minutes}�:{time.Seconds}�");
        else
            timeTextMesh.SetText($"{time.Seconds}�");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadSelectTest()
    {
        SceneManager.LoadScene("TestSelect");
    }
}
