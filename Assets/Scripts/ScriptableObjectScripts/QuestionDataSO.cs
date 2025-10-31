using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/no_ai", order = 0)]
public class QuestionNoAIDataSO : ScriptableObject
{
    public Image[] FirstImage;
    public Image[] SecondImage;
}

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/cringeSong", order = 1)]
public class CringeSongSO : ScriptableObject
{
    public GameObject[] Song;
}

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/onlyTsukiko", order = 2)]
public class OnlyTsukikoSO : ScriptableObject
{
    public Image[] FirstImage;
    public Image[] SecondImage;

    //Date
}

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/margsaContent", order = 3)]
public class MargsaContentSO : ScriptableObject
{
    public string[] Question;
}

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/findTheLost", order = 4)]
public class FindTheLostSO : ScriptableObject
{
    public Image[] Image;
}

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/memeZaur", order = 5)]
public class MemeZaurSO : ScriptableObject
{
    public Image[] FirstImage;
    public Image[] SecondImage;
}

[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/guessClip", order = 6)]
public class GuessClipSO : ScriptableObject
{
    public GameObject[] Clip;
}