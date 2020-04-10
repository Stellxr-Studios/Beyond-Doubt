using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
public class PlayButtonScript : ShootableUI
{
    // Start is called before the first frame update
    public VideoPlayerScript videoPlayer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void ShotClick(){
        Debug.Log("Button Pressed");
        videoPlayer.PlayPause();
    }
}
