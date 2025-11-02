using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/rawrQuestions", order = 7)]
public class RawrQuestionsSO : ScriptableObject
{
    public string[] Questions;
    public bool[] HasImage;
    public Sprite[] Sprites;

    public AnswerGroup[] answerGroup;

    [System.Serializable]
    public class AnswerGroup
    {
        public string[] Answer;
        public int CorrectAnswer;
    }
}
