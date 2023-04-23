using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Test", menuName = "Data/Test")]
[System.Serializable]
public class TestData : ScriptableObject
{
    public string Name;

    public List<QuestionData> questions;
}
