using PrimeTween;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    public static UILogic instance;
    [Header("UIElements")]
    [SerializeField] private GameObject _quizPanelParent;
    [SerializeField] private GameObject _questionPanelParent;
    [SerializeField] private GameObject _answerPanelParent;
    [SerializeField] private GameObject _returnToQestionsButton;
    [SerializeField] private List<Button> _answerButtonsList;

    private Dictionary<RectTransform, Vector2> _quizParentAllUIDictionary = new Dictionary<RectTransform, Vector2>();
    private Button _selectedQuestionButton;

    public Dictionary<RectTransform, Vector2> QuizParentAllUIDictionaty => _quizParentAllUIDictionary;
    public List<Button> AnswerButtonsList => _answerButtonsList;
    public Button SelectedQuestionButton
    {
        get { return _selectedQuestionButton; }
        set { _selectedQuestionButton = value; }
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
    }

    public void ShowQuestionPanel(CategoryType categoryType)
    {
        Dictionary<CategoryType, GameObject> questionPanelsDictionary = LoadElementManager.instance.QuestionPanelsDictionary;
        if (questionPanelsDictionary.ContainsKey(categoryType))
        {
            questionPanelsDictionary[categoryType].SetActive(true);
        }
    }

    public void HideQuestions()
    {
        foreach (var questionPanel in LoadElementManager.instance.QuestionPanelsDictionary)
        {
            questionPanel.Value.SetActive(false);
        }
    }

    public void ShowQuizPanel()
    {
        _quizPanelParent.SetActive(true);
        InQuizPanelAnimation();
    }

    public void HideQuizPanel()
    {
        foreach (var uiElement in _quizParentAllUIDictionary)
        {
            uiElement.Key.gameObject.SetActive(false);
        }
        _quizPanelParent.SetActive(false);
    }

    public void ShowAnswerPanel()
    {
        _answerPanelParent.SetActive(true);
    }

    public void HideAnswers()
    {
        _answerPanelParent.SetActive(false);
    }

    public void ReturnToQuestions()
    {
        HideQuestions();
        HideAnswers();
        ShowQuizPanel();
        ResetAnswerButtons();
        GameManager.instance.ResetCorrectAnswerValue();
    }

    public void MarkCompletedQuestion()
    {
        ColorBlock colors = _selectedQuestionButton.colors;
        colors.disabledColor = Color.lightGreen;
        _selectedQuestionButton.colors = colors;
        _selectedQuestionButton.interactable = false;
    }

    public void ResetAnswerButtons()
    {
        ColorBlock newColors = ColorBlock.defaultColorBlock;

        foreach (var answerButtonObj in AnswerButtonsList)
        {
            Button button = answerButtonObj.GetComponent<Button>();
            button.interactable = true;
            button.colors = newColors;

            answerButtonObj.GetComponentInChildren<TextMeshProUGUI>().SetText("-");
        }
    }

    public void InQuizPanelAnimation()
    {
        foreach (var uiElement in _quizParentAllUIDictionary)
        {
            uiElement.Key.gameObject.SetActive(false);
            Tween.StopAll(uiElement);
        }

        StartCoroutine(InQuizPanelAnimationCoroutine());
    }

    private IEnumerator InQuizPanelAnimationCoroutine()
    {
        foreach (var uiElement in _quizParentAllUIDictionary)
        {
            // Add offset to initial position to uiElement
            RectTransform recTransfrom = uiElement.Key.GetComponent<RectTransform>();
            Vector2 offsetPosition = recTransfrom.anchoredPosition + new Vector2 (0, -100);
            recTransfrom.anchoredPosition = offsetPosition;

            uiElement.Key.gameObject.SetActive(true);
            Vector2 targetPosition = uiElement.Value;
            Tween.UIAnchoredPosition(uiElement.Key, targetPosition, 0.3f, Ease.OutBack);
            yield return new WaitForSeconds(0.0125f);
        }
    }

    public void FadeImage(Image image, float alphaFrom, float alphaTo, float duration, float timeToResetAlpha = 0)
    {
        StartCoroutine(ImageFaderCoroutine(image, alphaFrom, alphaTo, duration, timeToResetAlpha));
    }

    private IEnumerator ImageFaderCoroutine(Image image,float alphaFrom, float alphaTo, float duration, float timeToResetAlpha)
    {
        float elapsedTime = 0f;
        Color color = image.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;

            color.a = Mathf.Lerp(alphaFrom, alphaTo, t);
            image.color = color;

            yield return null;
        }

        color.a = alphaTo;
        image.color = color;

        if (timeToResetAlpha != 0)
        {
            yield return new WaitForSeconds(timeToResetAlpha);
            color.a = alphaFrom;
            image.color = color;
        }
    }
}
