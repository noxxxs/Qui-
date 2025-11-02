using UnityEngine;


[CreateAssetMenu(fileName = "newCategory",menuName = "WWBMillionaire/Category",order = 0)]
public class CategoryContentSO : ScriptableObject
{
    [SerializeField] private CategoryType _categoryType;
    [SerializeField] private string _categoryName;
    [SerializeField] private int _questionNumber;
    [SerializeField] private int _categoryAnswerNumber;
    [SerializeField] private GameObject _questionPanelPrefab;

    public string CategoryName { 
        get {ValidatePropetryOnRead(_categoryName, "_categoryName");
            return _categoryName; } }
    public int QuestionNumber => _questionNumber;
    public int CategoryAnswerNumber => _categoryAnswerNumber;
    public CategoryType CategoryType => _categoryType;
    public GameObject QuestionPanelPrefab => _questionPanelPrefab;


    private void ValidatePropetryOnRead<T>(T value, string propertyName)
    {
        if (value is string str && string.IsNullOrEmpty(str))
        {
            Debug.Log($"{propertyName} - Property is empty!");
        }
    }
}
public enum CategoryType
{
    RawrQuestions,
    MargsaContent,
    FindTheLost,
    CringeMargsa,
    OnlyTsukiko,
    MemeZaur,
    GuessClip,
    No_AI,
}
