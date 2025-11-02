using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Scripts")]
    [SerializeField] private LoadElementManager _LoadElementManager;

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
        } else
        {
            Debug.Log("Wrong!");
        }
    }

    public void ResetCorrectAnswerValue()
    {
        _correctAnswer = 0;
    }
}
