using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class AnimationTriggerScript : MonoBehaviour
{
    // Start is called before the first frame update

    private VideoPlayer videoPlayer;
    public GameObject animationTarget;

    private bool animationTriggered;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Time "+ (int)videoPlayer.time);
        if((int)videoPlayer.time % 10 == 0 && !animationTriggered) {
            Debug.Log("Animation Triggered");
            animationTarget.GetComponent<Animator>().SetTrigger("animationTrigger");
            animationTriggered = true;
        }else {
            animationTriggered = false;
        }
        
    }
}
