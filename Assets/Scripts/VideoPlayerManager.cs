using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerManager : MonoBehaviour
{
    public static VideoPlayerManager instance;

    private VideoPlayer _videoPlayer;

    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        _videoPlayer.SetDirectAudioVolume(0, 0.25f);
    }

    public void OnVideoClipClick()
    {
        if (_videoPlayer.isPaused == true)
        {
            _videoPlayer.Stop();
            _videoPlayer.Play();
        }
        else
        {
            _videoPlayer.Pause();
        }
    }
}
