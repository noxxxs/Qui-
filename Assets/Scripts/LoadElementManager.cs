using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadElementManager : MonoBehaviour
{
    [SerializeField] private GameObject _quizParent;
    [SerializeField] private GameObject _categoryPanelPrefab;
    [SerializeField] private GameObject _categoryNamePrefab;
    [SerializeField] private GameObject _buttonPrefab;

    [Header("Categories in a Game")]
    [SerializeField] private List<CategorySO> _CategoryList;

    public void LoadQuizPanel()
    {
        foreach (CategorySO categorySO in _CategoryList)
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
                QuestionButtonData QuestionButtonData = questionButton.GetComponent<QuestionButtonData>();
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
}
