using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class start : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayVid() {
    VideoPlayer[] videoPlayers;
    videoPlayers = Resources.FindObjectsOfTypeAll<VideoPlayer>();
    foreach(VideoPlayer pv in videoPlayers){
        pv.Play();
    }

}
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
