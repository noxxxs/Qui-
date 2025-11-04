using UnityEngine;
using UnityEngine.UI;

public class QuestionButtonNavigation : MonoBehaviour
{
    private GameObject _quizPanel;
    private CategoryType _categoryType;
    private int _questionID;
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public CategoryType CategoryType {  
        get { return _categoryType; } 
        set { _categoryType = value; }
    }

    public int QuestionID
    {
        get { return _questionID; }
        set { _questionID = value; }
    }

    public GameObject QuizPanel
    {
        get { return _quizPanel; }
        set { _quizPanel = value; }
    }
    public void LoadNextQuestion()
    {
        LoadElementManager.instance.ShowNextQuestion(_categoryType, _questionID);
        LoadElementManager.instance.QuestionPanelsDictionary[_categoryType].SetActive(true);
        UILogic.instance.HideQuizPanel();
        UILogic.instance.SelectedQuestionButton = _button;
    }
}
