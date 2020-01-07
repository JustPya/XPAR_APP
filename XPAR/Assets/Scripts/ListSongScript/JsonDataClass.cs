using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class JsonDataClass
{
    public List<Song> message;
}

[System.Serializable]
public class Song
{
    public List<Instrument> instruments;
    public List<Resource> resources;
    public string _id;
    public string songName;
    public Band band;
}

[System.Serializable]
public class Instrument
{
    public string _id;
    public string name;
    public string resource;

}

[System.Serializable]
public class Resource
{
    public string _id;
    public string name;
    public string path;
    public string type;
    public string description;
    public string extension;

}

[System.Serializable]
public class Band
{
    public string _id;
    public string name;
    public string description;
    public List<Resource> resources;

}