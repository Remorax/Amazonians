using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;


public class videoplay : MonoBehaviour
{
    public RawImage rawImage;
    public VideoPlayer videoPlayer;
    public AudioSource audioSource;
    public float originalVolume;
    public CanvasGroup canvasGroup;

    void HideCanvas()
    {
        canvasGroup.alpha = 0f; //this makes everything transparent
        canvasGroup.blocksRaycasts = false; //this prevents the UI element to receive input events
    }

    void ShowCanvas()
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    void EndReached(VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        AudioListener.pause = false;
        HideCanvas();
    }

    public IEnumerator PlayVideo(string clip_name)
    {
        //videoPlayer.playbackSpeed = 1.0f;
        //Debug.LogWarning("hello");
        AudioListener.pause = true;
        videoPlayer.clip = Resources.Load<VideoClip>(clip_name);
        videoPlayer.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoPlayer.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        rawImage.texture = videoPlayer.texture;
        videoPlayer.loopPointReached += EndReached;
        ShowCanvas();

        videoPlayer.Play();
        audioSource.Play();


    }
}