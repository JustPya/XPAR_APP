using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DownloadSongData : MonoBehaviour
{

    private string URL_SONG = "http://192.168.1.4:3000/song/";
    private string URL = "http://192.168.1.4:3000/download/";
    private SongRequest song = new SongRequest();
    private string idSong;
    public Text progressText;
    public Text loadSceneText;
    public Slider slider;

    public TextMeshProUGUI bandName;
    public TextMeshProUGUI description;
    private int counter;
    private bool isLoadingGameScene;


    void Awake()
    {
        counter = 0;
        isLoadingGameScene = false;
        idSong = PlayerPrefs.GetString("idActualSong");
        Debug.Log(idSong);
        StartCoroutine(getSongData());
    }
    void Update()
    {
        downloadIsDone();
    }

    IEnumerator getSongData()
    {
        Debug.Log("Get song data started");
        UnityWebRequest www = UnityWebRequest.Get(URL_SONG + idSong);
        AsyncOperation request = www.SendWebRequest();

        while (!www.isDone)
        {
            Debug.Log(www.downloadProgress);
            yield return null;
        }
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Request error: " + www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            processJsonData(www.downloadHandler.text);
        }
    }

    private void processJsonData(string text)
    {
        song = JsonUtility.FromJson<SongRequest>(text);
        description.text = song.message.band.description;
        foreach (Instrument ins in song.message.instruments)
        {
            string idSong = ins.resource;
            Debug.Log(ins.resource);
            StartCoroutine(getVideosData(idSong));
            if (ins.name == "Voice")
            {
                PlayerPrefs.SetString("VoiceResource", ins.resource);
            }
            else if (ins.name == "Bass")
            {
                PlayerPrefs.SetString("BassResource", ins.resource);
            }
            else if (ins.name == "Guitar")
            {
                PlayerPrefs.SetString("GuitarResource", ins.resource);
            }
            else
            {
                PlayerPrefs.SetString("DrumsResource", ins.resource);
            }
        }
    }

    IEnumerator getVideosData(string idSong)
    {
        UnityWebRequest www = UnityWebRequest.Get(URL + idSong + ".mp4");
        AsyncOperation request = www.SendWebRequest();

        loadSceneText.enabled = true;

        while (!www.isDone)
        {
            float progress = Mathf.Clamp01(www.downloadProgress / .9f);
            slider.value = progress;
            progressText.text = Mathf.Round(progress * 100f) + " %";
            Debug.Log(Mathf.Round(progress * 100f) + " %");
            yield return null;
        }

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log("Request error: " + www.error);
        }
        else
        {
            Debug.Log("Request success!");
            counter = counter + 1;
            string filePath = Application.persistentDataPath + "/" + idSong + ".mp4";
            System.IO.File.WriteAllBytes(filePath, www.downloadHandler.data);
            Debug.Log(filePath);
            yield break;
        }
    }

    void downloadIsDone()
    {
        if (counter == 4)
        {
            slider.value = 1;
            progressText.text = 100 + " %";
            if (!isLoadingGameScene)
            {
                StartCoroutine(LoadGameScene());
            }
        }
    }

    IEnumerator LoadGameScene()
    {
        isLoadingGameScene = true;
        AsyncOperation operation = SceneManager.LoadSceneAsync(3);
        loadSceneText.text = "Cargando Escena...";
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressText.text = Mathf.Round(progress * 100f) + " %";
            yield return null;
        }
    }




}
