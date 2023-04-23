using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestSelectButton : MonoBehaviour
{
    private TestData data;

    public void Initialize(TestData testData)
    {
        data = testData;

        var testNameTextMesh = GetComponentInChildren<TextMeshProUGUI>();

        testNameTextMesh.text = data.Name;

        var buttonComponent = GetComponent<Button>();

        buttonComponent.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        TestSelectScript.lastSelectedData = data;

        SceneManager.LoadScene("Test");
    }
}
