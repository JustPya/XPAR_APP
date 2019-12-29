using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoFunctionality : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Awake(){
        videoPlayer = GetComponent<VideoPlayer> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Mute(){
        videoPlayer.SetDirectAudioMute(0, true);
    }

    public void UnMute(){
        videoPlayer.SetDirectAudioMute(0, false);
    }

    public void Play(){
        videoPlayer.Play();
    }
}
