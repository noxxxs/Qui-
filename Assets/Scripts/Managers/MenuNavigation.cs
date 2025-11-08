using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigation : MonoBehaviour
{
    public static MenuNavigation instance;
    
    [SerializeField] private GameObject _quitPanel;
    [SerializeField] private InputActionAsset _ActionAsset;

    private InputAction _escapeKeyAction;
    private string _ActionName = "Escape";

    private void OnEnable() => _escapeKeyAction.Enable();
    private void OnDisable() => _escapeKeyAction.Disable();

    private void Update()
    {
        if (_escapeKeyAction.WasPressedThisFrame())
        {
            HandleQuitPanel();
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);

        _escapeKeyAction = _ActionAsset.FindAction(_ActionName, true);
    }

    public void LoadQuizScene()
    {
        SceneManager.LoadScene("QuizScene");
    }


    public void HandleQuitPanel()
    {
        if (_quitPanel != null)
        {
            _quitPanel.SetActive(!_quitPanel.activeSelf);
        } else
        {
            SetQuitPanel();
            _quitPanel.SetActive(!_quitPanel.activeSelf);
        }
        
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }

    private void SetQuitPanel()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            _quitPanel = UILogic.instance.QuitPanel;
            UILogic.instance.ExitGameButton.onClick.AddListener(() => { QuitTheGame(); });
            UILogic.instance.ReturnButton.onClick.AddListener(() => { HandleQuitPanel(); });
        }
    }
}
