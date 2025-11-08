using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public static VideoPlayerManager instance;

    private VideoPlayer _videoPlayer;
    private GameObject _screenImage;

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

    public void VideoPlayerSetUp()
    {
        QuestionPanelContent questionPanelContent = LoadElementManager.instance.QuestionPanelsDictionary[CategoryType.GuessClip].GetComponent<QuestionPanelContent>();
        _screenImage = questionPanelContent.PanelObjectReferences[1];
        _videoPlayer = GetComponent<VideoPlayer>();
        
        _videoPlayer.SetDirectAudioVolume(0, 0.25f);
        _screenImage.GetComponent<Button>().onClick.AddListener(OnVideoClipClick);
    }

    // Button use this method
    public void OnVideoClipClick()
    {
        if (_videoPlayer.isPaused == true)
        {
            _videoPlayer.Play();
        }
        else
        {
            _videoPlayer.Pause();
        }
    }

    public void ChangeVideoClip(VideoClip newClip)
    {
        StartCoroutine(ChangeClipCoroutine(newClip));
    }

    private IEnumerator ChangeClipCoroutine(VideoClip newClip)
    {
        _videoPlayer.clip = newClip;
        _videoPlayer.Prepare();

        while (!_videoPlayer.isPrepared)
        {
            yield return new WaitForSeconds (0.1f);
        }
        _screenImage.SetActive(true);
        _videoPlayer.Play(); 
    }

    public void StopVideoPlayer()
    {
        _screenImage.SetActive(false);
        _videoPlayer.Stop();
    }
}
