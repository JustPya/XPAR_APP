using UnityEngine;
using UnityEngine.Events;
//using UnityEngine.Video;



public class TrackableEvent : DefaultTrackableEventHandler {

    public UnityEvent onTrackingFound;
    public UnityEvent onTrackingLost;

     void Awake(){
    }
    protected override void OnTrackingFound(){

        base.OnTrackingFound();
        onTrackingFound.Invoke();
    }

    protected override void OnTrackingLost(){   
        base.OnTrackingLost();
        onTrackingLost.Invoke();
    }
}