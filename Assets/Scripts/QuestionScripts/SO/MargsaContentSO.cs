using UnityEngine;

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/margsaContent", order = 3)]
public class MargsaContentSO : ScriptableObject
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