using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public static int CorrectAnswers;
    public static int CountQuestions;
    public static int time;

    public static TestData testData => TestSelectScript.lastSelectedData;

    [SerializeField] ScrollRect scrollView;
    [SerializeField] RectTransform content;
    [SerializeField] TextMeshProUGUI questionNumberText;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] ToggleGroup answers;
    [SerializeField] Button button;

    [SerializeField] AnswerPanel answerPrefab;

    private int currentQuestionNumber = 0;

    private QuestionData currentQuestionData => testData.questions[currentQuestionNumber];

    void Start()
    {
        CountQuestions = testData.questions.Count;
        CorrectAnswers = 0;
        time = 0;

        InvokeRepeating("AddTime", 0, 1);

        button.onClick.AddListener(OnButtonClick);

        DeleteQuestion();

        GenerateQuestion();

        UpdateUI();
    }

    private void AddTime()
    {
        time++;
    }

    public void GenerateQuestion()
    {
        SetQuestionNumber();

        //Set Question Text
        question.SetText(currentQuestionData.Question);

        //Generate Answers
        for (int answerNumber = 0; answerNumber < currentQuestionData.Answers.Count; answerNumber++)
        {
            var answerObject = Instantiate(answerPrefab, answers.transform);

            answerObject.transform.name = $"{answerNumber}";

            answerObject.Initialize(currentQuestionData.Answers[answerNumber], answers);
        }

        UpdateUI();
    }

    public void DeleteQuestion()
    {
        List<Transform> answers = new List<Transform>();

        for (int i = 0; i < this.answers.transform.childCount; i++)
            answers.Add(this.answers.transform.GetChild(i));

        foreach (var answer in answers)
            Destroy(answer.gameObject);

        UpdateUI();
    }

    private void SetQuestionNumber()
    {
        questionNumberText.text = $"Вопрос №{currentQuestionNumber + 1}";
    }

    public void OnButtonClick()
    {
        //Answer Check
        //answers.GetFirstActiveToggle
        {
            var selectedAnswer = answers.GetFirstActiveToggle();

            if (selectedAnswer == null) return;

            if (System.Convert.ToInt32(selectedAnswer.transform.parent.name) == currentQuestionData.CorrectNumber)
                CorrectAnswers++;
        }

        NextQuestion();
    }

    public void NextQuestion()
    {
        if (currentQuestionNumber == CountQuestions - 1)
        {
            SceneManager.LoadScene("Result");

            return;
        }

        currentQuestionNumber++;

        DeleteQuestion();

        GenerateQuestion();

        UpdateUI();

        ScrollToTop();
    }

    private void RefreshContentFitter(RectTransform transform)
    {
        if (transform == null || !transform.gameObject.activeSelf) return;

        foreach (RectTransform child in transform)
            RefreshContentFitter(child);

        var layoutGroup = transform.GetComponent<LayoutGroup>();
        var contentSizeFitter = transform.GetComponent<ContentSizeFitter>();

        if (layoutGroup != null)
        {
            layoutGroup.SetLayoutHorizontal();
            layoutGroup.SetLayoutVertical();
        }

        if (contentSizeFitter != null)
        {
            contentSizeFitter.enabled = false;
            contentSizeFitter.enabled = true;
            LayoutRebuilder.ForceRebuildLayoutImmediate(transform);
        }
    }
    private void UpdateUI()
    {
        RefreshContentFitter(content);

        //var layoutGroups = content.GetComponentsInChildren<LayoutGroup>();

        //for(int i = layoutGroups.Length - 1; i >= 0; i--)
        //{
        //    LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroups[i].transform as RectTransform);
        //}

        //foreach (var layoutgroup in layoutGroups)
        //LayoutRebuilder.ForceRebuildLayoutImmediate(layoutgroup.transform as RectTransform);

        //Canvas.ForceUpdateCanvases();


        //LayoutRebuilder.ForceRebuildLayoutImmediate(questionNumberText.transform as RectTransform);
        //LayoutRebuilder.ForceRebuildLayoutImmediate(question.transform as RectTransform);

        //LayoutRebuilder.ForceRebuildLayoutImmediate(answers.transform as RectTransform);
        //for (int i = 0; i < this.answers.transform.childCount; i++)
        //{
        //    var answer = this.answers.transform.GetChild(i);
        //    LayoutRebuilder.ForceRebuildLayoutImmediate(answer as RectTransform);
        //}

        //LayoutRebuilder.ForceRebuildLayoutImmediate(content);
    }

    private void ScrollToTop()
    {
        scrollView.normalizedPosition = new Vector2(0, 1);
    }

    private void ScrollToBottom()
    {
        scrollView.normalizedPosition = new Vector2(0, 0);
    }
}
