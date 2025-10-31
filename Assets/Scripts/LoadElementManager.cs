using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadElementManager : MonoBehaviour
{
    public static LoadElementManager instance;

    [SerializeField] private GameObject _quizParent;
    [SerializeField] private GameObject _categoryPanelPrefab;
    [SerializeField] private GameObject _categoryNamePrefab;
    [SerializeField] private GameObject _buttonPrefab;

    [Header("CategoriesSO")]
    [SerializeField] private List<CategorySO> _categoryList;

    [Header("QuestionSO")]
    [SerializeField] private QuestionNoAIDataSO _noAIDataSO;
    [SerializeField] private CringeSongSO _сringeSongSO;
    [SerializeField] private OnlyTsukikoSO _onlyTsukikoSO;
    [SerializeField] private MargsaContentSO _margsaContentSO;
    [SerializeField] private FindTheLostSO _findTheLostSO;
    [SerializeField] private MemeZaurSO _memeZaurSO;
    [SerializeField] private GuessClipSO _guessClipSO;

    [Header("UIElemetns")]
    [SerializeField] private List<Button> _answerButtons;
    [SerializeField] private GameObject _answerPanel;

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

    public void LoadQuizPanel()
    {
        foreach (CategorySO categorySO in _categoryList) 
        {
            //Spawn Category Panel
            GameObject categoryPanel = Instantiate(_categoryPanelPrefab);
            categoryPanel.name = $"Category_{categorySO.CategoryName}";
            categoryPanel.transform.SetParent(_quizParent.transform, false);

            // Spawn Category Name
            GameObject categoryName = Instantiate(_categoryNamePrefab);
            categoryName.transform.SetParent(categoryPanel.transform, false);
            categoryName.name = categorySO.CategoryName;
            categoryName.GetComponentInChildren<TextMeshProUGUI>().SetText(categorySO.CategoryName);

            // Spawn Question Buttons
            for (int i = 0; i < categorySO.QuestionNumber; i++)
            {
                GameObject questionButton = Instantiate(_buttonPrefab);
                questionButton.transform.SetParent(categoryPanel.transform, false);
                questionButton.name = $"Button_{i+1}";
                questionButton.GetComponentInChildren<TextMeshProUGUI>().SetText($"{(i + 1)}");


                // Set data to navigate to target question
                QuestionButtonNavigation QuestionButtonData = questionButton.GetComponent<QuestionButtonNavigation>();
                QuestionButtonData.CategoryType = categorySO.Category;
                QuestionButtonData.QuestionID = i + 1;
                QuestionButtonData.QuizPanel = _quizParent;
                // Add event to question button
                questionButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    QuestionButtonData.LoadNextQuestion();
                    QuestionButtonData.QuizPanel.SetActive(false);
                });
            }
        }
    }

    public void ShowNextQuestion()
    {
        SetUpAnswer();
        ShowAnswerPanel();
    }

    public void SetUpAnswer()
    {

    }

    public void ShowAnswerPanel()
    {
        _answerPanel.SetActive(true);
    }
}
