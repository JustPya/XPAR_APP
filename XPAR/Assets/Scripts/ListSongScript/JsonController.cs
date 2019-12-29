using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class JsonController : MonoBehaviour
{
    private string URL = "http://192.168.1.6:3000/song/";
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;
    public JsonDataClass jsnData = new JsonDataClass();

    void Awake() {
     StartCoroutine(getData());    
    }
    void Start()
    {
       
    }

    IEnumerator getData() {
        Debug.Log("Get Data started");
        UnityWebRequest www = UnityWebRequest.Get(URL);
        AsyncOperation request = www.SendWebRequest();

        while(!www.isDone){
            Debug.Log(www.downloadProgress);
            yield return null;
        }
        
        if(www.isNetworkError || www.isHttpError){
            Debug.LogError("Request error: " + www.error);
        }
        else{
            Debug.Log(www.downloadHandler.text);
            processJsonData(www.downloadHandler.text);
        }
    }

    private void processJsonData(string text) {
    jsnData = JsonUtility.FromJson<JsonDataClass>(text);
    foreach(Song song in jsnData.songs){
        string songName = song.songName;
        string bandName = song.band.name;
        string idSong = song._id;
        generateItem(songName, bandName, idSong);
    }
        scrollView.verticalNormalizedPosition = 1;
    }

    void generateItem (string songName, string bandName, string idSong){
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);

        scrollItemObj.transform.Find("song").gameObject.GetComponent<TextMeshProUGUI>().text = songName;
        scrollItemObj.transform.Find("band").gameObject.GetComponent<TextMeshProUGUI>().text = bandName;
        scrollItemObj.transform.Find("id").gameObject.GetComponent<Text>().text = idSong;
    }

    void access(){
        foreach(Song x in jsnData.songs){
            Debug.Log("ID SONG  " + x._id);
        }   
    }

    public void OnClick()
    {
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);
    }
}
