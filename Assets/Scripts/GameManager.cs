using PrimeTween;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private CategoryType _selectedCategory;
    private Button _pressedAnswerButton;
    private int _correctAnswer = 0;
    public int СorrectAnswer
    {
        get { return _correctAnswer; }
        set {  _correctAnswer = value; }   
    }
    
    public CategoryType SelectedCategory
    {
        get { return _selectedCategory; }
        set { _selectedCategory = value; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        LoadElementManager.instance.LoadQuizPanel();
    }

    public void ValidateAnswer(int selectedAnswer)
    {
        _pressedAnswerButton = UILogic.instance.AnswerButtonsList[selectedAnswer - 1].GetComponent<Button>();

        if (_correctAnswer != 0 && selectedAnswer == _correctAnswer)
        {
            StartCoroutine(OnCorrectAnswer());
            HandlePressedAnswerButton(true);
        } else
        {
            HandlePressedAnswerButton(false);
        }
    }

    private IEnumerator OnCorrectAnswer()
    {
        yield return null; 

        if (_selectedCategory == CategoryType.FindTheLost)
        {
            UILogic.instance.FadeImage(LoadElementManager.instance.HidenImage, 1, 0, 0.5f, 2f);
            yield return new WaitForSeconds(2f);
        }
        UILogic.instance.HideQuestions();
        UILogic.instance.HideAnswers();
        UILogic.instance.ShowQuizPanel();

        // Reset CorrectAnswer value
        ResetCorrectAnswerValue();

        UILogic.instance.ResetAnswerButtons();
        UILogic.instance.MarkCompletedQuestion();
    }

    public void ResetCorrectAnswerValue()
    {
        _correctAnswer = 0;
    }

    private void HandlePressedAnswerButton(bool isAnswerCorrect)
    {
        ColorBlock colors;
        if (isAnswerCorrect)
        {
            colors = _pressedAnswerButton.colors;
            colors.disabledColor = Color.lightGreen;
            _pressedAnswerButton.colors = colors;
            _pressedAnswerButton.interactable = false;

            foreach (var button in UILogic.instance.AnswerButtonsList)
            {
                button.interactable = false;
            }
        } else
        {
            colors = _pressedAnswerButton.colors;
            colors.disabledColor = Color.red;
            _pressedAnswerButton.colors = colors;
            _pressedAnswerButton.interactable = false;
        }
       
    }
}
