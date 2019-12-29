using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Listadenombres : MonoBehaviour
{
   public List<string> vn {get; set;} 
   
     List<string> videosName(){
     List<string> vn = new List<string>();
      vn.Add("Voz.mp4");
      vn.Add("Bajo.mp4");
      vn.Add("Bateria.mp4");
      vn.Add("Guitarra.mp4");
      foreach(string s in vn){
          //Debug.Log(s);
      }
      return vn;
     }
     
    void Start()
    {
        vn  = videosName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
