using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
class PrepareVideos : MonoBehaviour{

    private string voiceResource;    
    private string bassResource;
    private string drumsResource;    
    private string guitarResource;
    void Awake() {
        voiceResource = PlayerPrefs.GetString("VoiceResource");
        bassResource = PlayerPrefs.GetString("BassResource");
        drumsResource = PlayerPrefs.GetString("DrumsResource");
        guitarResource = PlayerPrefs.GetString("GuitarResource");
    StartCoroutine(prepareVideos());
    }
    IEnumerator  prepareVideos(){
        VideoPlayer[] videoPlayers;
        videoPlayers = Resources.FindObjectsOfTypeAll<VideoPlayer>();
        Debug.Log(Application.persistentDataPath);
        foreach (VideoPlayer pv in videoPlayers){
            if(pv.name == "VideoPlayerVoice"){
                Debug.Log("Encontré Video Player Voice");
                pv.url = Application.persistentDataPath+"/"+voiceResource+".mp4";
                pv.Prepare();
                while(!pv.isPrepared){
                    Debug.Log("VOZ es preparando audfdfha");
                    yield return null;
                }
            }
            else if(pv.name == "VideoPlayerGuitar"){
                Debug.Log("Encontré Video Player Guitar");
                pv.url = Application.persistentDataPath+"/"+guitarResource+".mp4";
                pv.Prepare();
                while(!pv.isPrepared){
                    Debug.Log("GUITARRA es preparando audfdfha");
                    yield return null;
                }
            }
            else if(pv.name == "VideoPlayerBass"){
                pv.url = Application.persistentDataPath+"/"+bassResource+".mp4";
                pv.Prepare();
                while(!pv.isPrepared){
                    Debug.Log("BAJO es preparando audfdfha");
                    yield return null;
                }
            }
            else{
                pv.url = Application.persistentDataPath+"/"+drumsResource+".mp4";
                pv.Prepare();
                while(!pv.isPrepared){
                    Debug.Log("BATERIA es preparando audfdfha");
                    yield return null;
                }
            }
        }
    }
    
    // Start is called before the first frame update
    void Start(){
        //listadenombres.vn;

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
