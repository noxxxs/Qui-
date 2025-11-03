using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Scripts")]
    [SerializeField] private LoadElementManager _LoadElementManager;

    private Button _pressedAnswerButton;
    private int _correctAnswer = 0;
    public int СorrectAnswer
    {
        get { return _correctAnswer; }
        set {  _correctAnswer = value; }   
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
        _LoadElementManager.LoadQuizPanel();
    }

    public void ValidateAnswer(int selectedAnswer)
    {
        if (_correctAnswer != 0 &&  _correctAnswer == selectedAnswer)
        {
            UILogic.instance.HideQuestionPanel();
            UILogic.instance.HideAnswerPanel();
            UILogic.instance.ShowQuizPanel();
            Debug.Log("Nice!");

            // Reset CorrectAnswer value
            ResetCorrectAnswerValue();
            UILogic.instance.ResetAnswerButtonsStyle();
            UILogic.instance.HandleSelectedQuestionButton();
           
        } else if (selectedAnswer != 0)
        {
            _pressedAnswerButton = UILogic.instance.AnswerButtonsList[selectedAnswer - 1].GetComponent<Button>();
            HandleWrongPressedAnswer();
            Debug.Log("Wrong!");
        }
    }

    public void ResetCorrectAnswerValue()
    {
        _correctAnswer = 0;
    }

    private void HandleWrongPressedAnswer()
    {
        ColorBlock colors = _pressedAnswerButton.colors;
        colors.disabledColor = Color.red;
        _pressedAnswerButton.colors = colors;
        _pressedAnswerButton.interactable = false;
    }

    
}
