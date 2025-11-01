using UnityEngine;

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/guessClip", order = 6)]
public class GuessClipSO : ScriptableObject
{
    public GameObject[] Clip;
}