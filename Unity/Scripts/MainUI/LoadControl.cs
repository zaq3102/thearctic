using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class LoadControl : MonoBehaviour
{
    public List<PlayableDirector> timelines;
 
    public static int currentTimeline=0;

    void Start()
    {
        PlayableDirector current = timelines[currentTimeline];
        current.Play();
    }
 
    void Update()
    {
     
    }
}
