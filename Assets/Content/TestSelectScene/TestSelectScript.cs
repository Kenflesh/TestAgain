using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSelectScript : MonoBehaviour
{
    public static TestData lastSelectedData;

    public Transform Content;
    public TestSelectButton ButtonPrefab;

    void Start()
    {
        GeneratgeButtons();
        UpdateUI();
    }

    void GeneratgeButtons()
    {
        var testsData = Resources.LoadAll<TestData>("Tests");

        foreach (var testData in testsData)
        {
            var testButton = Instantiate(ButtonPrefab, Content);

            testButton.Initialize(testData);
        }
    }

    void UpdateUI()
    {
        LayoutRebuilder.ForceRebuildLayoutImmediate(Content as RectTransform);
    }
}
