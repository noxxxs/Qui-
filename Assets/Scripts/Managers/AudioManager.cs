using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance { get; private set; }

    [Header("Audio Sources")]
    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _uiSource;

    [Header("UI Sounds")]
    [SerializeField] private AudioClip _buttonClick;
    [SerializeField] private AudioClip _rawrSFX;
    [SerializeField] private AudioClip _wrongAnswer;
    [SerializeField] private AudioClip _correctAnswer;

    [Header("Settings")]
    [Range(0f, 1f)]
    [SerializeField] private float _masterVolume = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float _sfxVolume = 1f;
    [Range(0f, 1f)]
    [SerializeField] private float _uiVolume = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudioSources();
            LoadPlayerPrefs();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudioSources()
    {

        if (_sfxSource == null)
        {
            _sfxSource = gameObject.AddComponent<AudioSource>();
            _sfxSource.playOnAwake = false;
        }

        if (_uiSource == null)
        {
            _uiSource = gameObject.AddComponent<AudioSource>();
            _uiSource.playOnAwake = false;
        }

        UpdateVolumes();
    }

    private void LoadPlayerPrefs()
    {
        _masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        _sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        _uiVolume = PlayerPrefs.GetFloat("UIVolume", 1f);
        UpdateVolumes();
    }

    private void SavePlayerPrefs()
    {
        PlayerPrefs.SetFloat("MasterVolume", _masterVolume);
        PlayerPrefs.SetFloat("SFXVolume", _sfxVolume);
        PlayerPrefs.SetFloat("UIVolume", _uiVolume);
        PlayerPrefs.Save();
    }

    // UI звуки
    public void PlayButtonClick()
    {
        PlaySFX(_buttonClick, 0.35f);
    }

    public void PlayCorrectAnswer()
    {
        PlaySFX(_correctAnswer, 0.20f);
    }

    public void PlayWrongAnswer()
    {
        PlaySFX(_wrongAnswer, 0.2f);
    }

    public void PlayRawrSound()
    {
        PlaySFX(_rawrSFX, 0.45f);
    }

    public void PlayUISound(AudioClip clip)
    {
        if (clip != null && _uiSource != null)
        {
            _uiSource.PlayOneShot(clip);
        }
    }

    // Ігрові звуки
    public void PlaySFX(AudioClip clip, float volumeScale = 1f)
    {
        if (clip != null && _sfxSource != null)
        {
            _sfxSource.PlayOneShot(clip, volumeScale);
        }
    }


    // Налаштування гучності
    public void SetMasterVolume(float volume)
    {
        _masterVolume = Mathf.Clamp01(volume);
        UpdateVolumes();
        SavePlayerPrefs();
    }


    public void SetSFXVolume(float volume)
    {
        _sfxVolume = Mathf.Clamp01(volume);
        UpdateVolumes();
        SavePlayerPrefs();
    }

    public void SetUIVolume(float volume)
    {
        _uiVolume = Mathf.Clamp01(volume);
        UpdateVolumes();
        SavePlayerPrefs();
    }

    private void UpdateVolumes()
    {
        if (_sfxSource != null)
            _sfxSource.volume = _masterVolume * _sfxVolume;

        if (_uiSource != null)
            _uiSource.volume = _masterVolume * _uiVolume;
    }

    public float GetMasterVolume() => _masterVolume;
    public float GetSFXVolume() => _sfxVolume;
    public float GetUIVolume() => _uiVolume;
}