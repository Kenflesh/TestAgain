using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData
{
    [TextArea]
    public string Question;

    [TextArea]
    public List<string> Answers;

    public int CorrectNumber;
}