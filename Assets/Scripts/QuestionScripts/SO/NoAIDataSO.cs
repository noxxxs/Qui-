using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "newQuestionData", menuName = "WWBMillionaire/Question/no_ai", order = 0)]
public class NoAIDataSO : ScriptableObject
{
    public string[] Questions;
    public Image[] FirstImage;
    public Image[] SecondImage;
}
