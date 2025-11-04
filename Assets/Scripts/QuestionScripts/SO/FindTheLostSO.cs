using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/findTheLost", order = 4)]
public class FindTheLostSO : ScriptableObject
{
    public string[] Questions;
    public Sprite[] Sprites;

    public AnswerGroup[] answerGroup;

    [System.Serializable]
    public class AnswerGroup
    {
        public string[] Answer;
        public int CorrectAnswer;
    }
}