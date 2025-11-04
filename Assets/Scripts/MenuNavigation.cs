using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void LoadQuizScene()
    {
        SceneManager.LoadScene("QuizScene");
    }
}
