using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundResumeManager : MonoBehaviour
{
    public static SoundResumeManager instance;

    private Slider _slider;
    private Button _resumeButton;
    private TextMeshProUGUI _soundTimerText;
    private AudioSource _audioSource;
    private AudioClip _audioClip;
    public AudioClip AudioClip
    {
        get { return _audioClip; }
        set { _audioClip = value; 
            OnChangeSound(_audioClip); }
    }

    private float _soundTimer;
    private float _soundDuration;
    private bool _isPlaying = false;
   // private bool _isFinished = true;

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


    private void Update()
    {
        if (_soundTimer < _soundDuration && _isPlaying)
        {
            // Let sound play
            _soundTimer += Time.deltaTime;
            UpdateTimerText();
            _slider.SetValueWithoutNotify(_soundTimer);
        }

        if (_soundTimer >= _soundDuration && _isPlaying)
        {
            ResetSoundResuming();
        }
            
    }

    //Only if drag in Game View
    private void OnChangeSound(AudioClip newAudioClip)
    {
        _soundDuration = newAudioClip.length;
        _slider.maxValue = _soundDuration;
        _audioSource.clip = newAudioClip;

        //Reset Timer to start position
        ResetSoundResuming();

    }


    public void Init()
    {
        QuestionPanelContent questionPanelContent = LoadElementManager.instance.QuestionPanelsDictionary[CategoryType.CringeMargsa].GetComponent<QuestionPanelContent>();
        _slider = questionPanelContent.PanelObjectReferences[1].GetComponent<Slider>();
        _soundTimerText = questionPanelContent.PanelObjectReferences[2].GetComponent<TextMeshProUGUI>();
        _resumeButton = questionPanelContent.PanelObjectReferences[3].GetComponent<Button>();

        _resumeButton.onClick.AddListener(OnResumeButtonClick);

        _audioSource = GetComponent<AudioSource>();
    }

    private void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(_soundTimer / 60f);
        int seconds = Mathf.FloorToInt(_soundTimer % 60);
        _soundTimerText.SetText($"{minutes:00}:{seconds:00}");
    }

    public void OnResumeButtonClick()
    {
        // Pause wile playing
        if (_audioSource.time > 0 && _isPlaying)
        {
            _audioSource.Pause();
            _isPlaying = false;
 
        } 
        // Unpause
        else if (_audioSource.time > 0 && !_isPlaying)
        {
            _audioSource.UnPause();
            _isPlaying = true;
        } 
        // Play from start
        else if (_audioSource.time == 0 && !_isPlaying)
        {
            ResetSoundResuming();
            _audioSource.Play();
            _isPlaying = true;
        }
    }

    private void ResetSoundResuming()
    {
        _slider.SetValueWithoutNotify(0);
        _soundTimer = 0;
        UpdateTimerText();
        _isPlaying = false;
    }

}
