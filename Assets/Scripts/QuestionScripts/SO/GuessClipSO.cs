using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/guessClip", order = 6)]
public class GuessClipSO : ScriptableObject
{
    public string[] Questions;

    public VideoClip[] VideoClips;

    public AnswerGroup[] answerGroup;

    [System.Serializable]
    public class AnswerGroup
    {
        public string[] Answer;
        public int CorrectAnswer;
    }
}