using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;


public class Onclick : MonoBehaviour {

    private static string idSong;
    public void GetId() {
        GameObject song = EventSystem.current.currentSelectedGameObject;
        idSong = song.transform.Find("id").gameObject.GetComponent<Text>().text;
        Debug.Log("ESTE ID" +  idSong);
        PlayerPrefs.SetString("idActualSong" , idSong);
        SceneManager.LoadScene(2);
        
    }

    public void DownloadGameScene() {
        Debug.Log(idSong);
    }
}
