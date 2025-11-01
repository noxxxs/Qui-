using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("Scripts")]
    [SerializeField] private LoadElementManager _LoadElementManager;

    [SerializeField] private Dictionary<CategoryType, GameObject> _questionCategoryPanels = new Dictionary<CategoryType, GameObject>();

    public Dictionary<CategoryType, GameObject> QuestionCategoryPanels => _questionCategoryPanels;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    void Start()
    {
        _LoadElementManager.LoadQuizPanel();
    }


}
