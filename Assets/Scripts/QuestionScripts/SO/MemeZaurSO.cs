using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/memeZaur", order = 5)]
public class MemeZaurSO : ScriptableObject
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