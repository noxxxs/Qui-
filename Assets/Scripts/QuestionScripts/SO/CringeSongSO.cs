using UnityEngine;

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/cringeSong", order = 1)]
public class CringeSongSO : ScriptableObject
{
    public string[] Questions;
    public AudioClip[] AudioClips;

    public AnswerGroup[] answerGroup;

    [System.Serializable]
    public class AnswerGroup
    {
        public string[] Answer;
        public int CorrectAnswer;
    }
}