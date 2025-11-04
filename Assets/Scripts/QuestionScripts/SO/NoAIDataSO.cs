using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/no_ai", order = 0)]
public class NoAIDataSO : ScriptableObject
{
    public string[] Questions;

    public Sprite[] FirstSprites;
    public Sprite[] SecondSprites;

    public AnswerGroup[] answerGroup;

    [System.Serializable]
    public class AnswerGroup
    {
        public string[] Answer;
        public int CorrectAnswer;
    }
}
