using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    public static UILogic instance;
    [Header("UIElements")]
    [SerializeField] private GameObject _quizPanelParent;
    [SerializeField] private GameObject _questionPanelParent;
    [SerializeField] private GameObject _answerPanelParent;
    [SerializeField] private GameObject _returnToQestionsButton;
    [SerializeField] private List<Button> _answerButtons;

    public List<Button> AnswerButtons => _answerButtons;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    public void ShowQuestionPanel(CategoryType categoryType)
    {
        Dictionary<CategoryType, GameObject> questionPanelsDictionary = LoadElementManager.instance.QuestionPanelsDictionary;
        if (questionPanelsDictionary.ContainsKey(categoryType))
        {
            questionPanelsDictionary[categoryType].SetActive(true);
        }
    }

    public void HideQuestionPanel()
    {
        foreach (var questionPanel in LoadElementManager.instance.QuestionPanelsDictionary)
        {
            questionPanel.Value.SetActive(false);
        }
    }

    public void ShowQuizPanel()
    {
        _quizPanelParent.SetActive(true);
    }

    public void HideQuizPanel()
    {
        _quizPanelParent.SetActive(false);
    }

    public void ShowAnswerPanel()
    {
        _answerPanelParent.SetActive(true);
    }

    public void HideAnswerPanel()
    {
        _answerPanelParent.SetActive(false);
    }

    public void ReturnToQuestions()
    {
        HideQuestionPanel();
        HideAnswerPanel();
        ShowQuizPanel();
        GameManager.instance.ResetCorrectAnswerValue();
    }
}
