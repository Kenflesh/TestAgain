using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadTheory : MonoBehaviour
{
    void Start()
    {
        var textMesh = GetComponent<TextMeshProUGUI>();

        var theoryTextAsset = Resources.Load<TextAsset>("Theory");

        textMesh.text = theoryTextAsset.text;
    }
}
