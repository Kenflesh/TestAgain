using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Toggle toggle;

    public void Initialize(string answer, ToggleGroup group)
    {
        text.SetText(answer);

        toggle.group = group;
    }
}
