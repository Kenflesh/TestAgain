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
            timeTextMesh.SetText($"{time.Hours}÷:{time.Minutes}ì:{time.Seconds}ñ");
        else if (time.Minutes > 0)
            timeTextMesh.SetText($"{time.Minutes}ì:{time.Seconds}ñ");
        else
            timeTextMesh.SetText($"{time.Seconds}ñ");
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
