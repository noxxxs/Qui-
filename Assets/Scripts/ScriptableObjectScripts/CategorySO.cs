using UnityEngine;


[CreateAssetMenu(fileName = "newCategory",menuName = "WWBMillionaire/Category",order = 0)]
public class CategorySO : ScriptableObject
{
    [SerializeField] private string _categoryName;
    [SerializeField] private int _questionNumber;
    [SerializeField] private int _categoryAnswerNumber;
    [SerializeField] private CategoryType _category;
    private int _questionID;

    public string CategoryName { 
        get {ValidatePropetryOnRead(_categoryName, "_categoryName");
            return _categoryName; } }
    public int QuestionNumber => _questionNumber;
    public int CategoryAnswerNumber => _categoryAnswerNumber;
    public CategoryType Category => _category;
    public int QuestionID {  
        get { return _questionID; }
        set { _questionID = value; } 
    }

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
    Photo, Second, Third
}
