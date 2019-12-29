using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ListSongsRequest : MonoBehaviour{
    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;
    private string URL = "http://192.168.1.6:3000/song/";
    public JsonDataClass jsnData = new JsonDataClass();

    void Awake() {
     StartCoroutine(getData());    
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
            //processJsonData(www.downloadHandler.text);
        }
    }


    
    void generateItem (int itemNumber){
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);
        scrollItemObj.transform.Find("Text").gameObject.GetComponent<Text>().text = itemNumber.ToString();
    }
}
