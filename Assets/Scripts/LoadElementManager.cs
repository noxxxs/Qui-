using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadElementManager : MonoBehaviour
{
    public static LoadElementManager instance;

    [Header("Prefabs")]
    [SerializeField] private GameObject _categoryPanelPrefab;
    [SerializeField] private GameObject _categoryNamePrefab;
    [SerializeField] private GameObject _buttonPrefab;

    [Header("UIElemetns")]
    [SerializeField] private GameObject _quizParent;
    [SerializeField] private GameObject _questionPanelParent;

    [Header("CategoriesSO")]
    [SerializeField] private List<CategoryContentSO> _categoryContentList;

    [Header("QuestionDataSO")]
    [SerializeField] private RawrQuestionsSO _rawrQuestionSO;
    [SerializeField] private NoAIDataSO _noAIDataSO;
    [SerializeField] private CringeSongSO _сringeSongSO;
    [SerializeField] private OnlyTsukikoSO _onlyTsukikoSO;
    [SerializeField] private MargsaContentSO _margsaContentSO;
    [SerializeField] private FindTheLostSO _findTheLostSO;
    [SerializeField] private MemeZaurSO _memeZaurSO;
    [SerializeField] private GuessClipSO _guessClipSO;

   

    // private properties
    private Dictionary<CategoryType, GameObject> _questionPanelsDictionary = new Dictionary<CategoryType, GameObject>();
    public Dictionary<CategoryType, GameObject> QuestionPanelsDictionary => _questionPanelsDictionary;

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
        foreach (CategoryContentSO categorySO in _categoryContentList) 
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


            for (int i = 0; i < categorySO.QuestionNumber; i++)
            {
                GameObject questionButton = Instantiate(_buttonPrefab);
                questionButton.transform.SetParent(categoryPanel.transform, false);
                questionButton.name = $"Button_{i+1}";
                questionButton.GetComponentInChildren<TextMeshProUGUI>().SetText($"{(i + 1)}");


                // Set data to navigate to target question
                QuestionButtonNavigation QuestionButtonData = questionButton.GetComponent<QuestionButtonNavigation>();
                QuestionButtonData.CategoryType = categorySO.CategoryType;
                QuestionButtonData.QuestionID = i + 1;
                QuestionButtonData.QuizPanel = _quizParent;
                // Add event to question button
                questionButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    QuestionButtonData.LoadNextQuestion();
                    QuestionButtonData.QuizPanel.SetActive(false);
                });
            }
            // Spawn and deactivate QuestionPanels for each category
            GameObject questionPanel = Instantiate(categorySO.QuestionPanelPrefab);
            questionPanel.SetActive(false);
            questionPanel.transform.SetParent(_questionPanelParent.transform, false);
            

            // Throw log exeption
            if (!_questionPanelsDictionary.TryAdd(categorySO.CategoryType, questionPanel))
                throw new System.Exception("Category SO Data has wrong values");
        }
    }

    public void ShowNextQuestion(CategoryType categoryType, int questionID)
    {
        SetNewAnswerOptions(categoryType, questionID);
        SetNewQuesiton(categoryType, questionID);

        UILogic.instance.ShowQuestionPanel(categoryType);
        UILogic.instance.ShowAnswerPanel();
    }


    public void SetNewQuesiton(CategoryType categoryType, int questionID)
    {
        if (_questionPanelsDictionary.ContainsKey(categoryType))
        {
            switch (categoryType)
            {
                case CategoryType.RawrQuestions:
                    {
                        QuestionPanelContent questionPanelContent = _questionPanelsDictionary[categoryType].GetComponent<QuestionPanelContent>();
                        questionPanelContent.PanelObjectReferences[0].GetComponent<TextMeshProUGUI>().SetText(_rawrQuestionSO.Questions[questionID - 1]);
                        // Enable image if needs
                        if (_rawrQuestionSO.HasImage[questionID - 1])
                        {
                            questionPanelContent.PanelObjectReferences[1].GetComponent<Image>().sprite = _rawrQuestionSO.Sprites[questionID - 1];
                            questionPanelContent.PanelObjectReferences[1].SetActive(true);
                        } else
                        {
                            questionPanelContent.PanelObjectReferences[1].SetActive(false);
                        }
                    }
                    break;
            }
        }
    }

    public void SetNewAnswerOptions(CategoryType categoryType, int questionID)
    {
        if (_questionPanelsDictionary.ContainsKey(categoryType))
        {
            switch (categoryType)
            {
                case CategoryType.RawrQuestions:
                    {
                        for (int i = 0; i < UILogic.instance.AnswerButtons.Count; i++)
                        {
                            UILogic.instance.AnswerButtons[i].GetComponentInChildren<TextMeshProUGUI>().SetText(_rawrQuestionSO.answerGroup[questionID - 1].Answer[i]);
                        }
                        // Set correct answer
                        GameManager.instance.СorrectAnswer = _rawrQuestionSO.answerGroup[questionID - 1].CorrectAnswer;

                    }
                    break;
            }
        }
    }
}
