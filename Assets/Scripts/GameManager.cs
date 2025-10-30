using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] private LoadElementManager _LoadElementManager;
    void Start()
    {
        _LoadElementManager.LoadQuizPanel();
    }

}
