using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private VideoPlayer videoPlayer; 

    public VideoClip[] videoClips;

    private int currentIndex;

    void Awake(){
        videoPlayer = GetComponent<VideoPlayer>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100)){
                Debug.DrawRay(ray.origin, hit.point);
                
                ShootableUI shootUI = hit.collider.GetComponent<ShootableUI>();
                Debug.Log("ShootUI "+shootUI);
                if (shootUI != null) {
                    Debug.Log("Did Hit");
                    shootUI.ShotClick();
                }
            }
        }
    }

    public void PlayPause() {
        if(videoPlayer.isPlaying){
            videoPlayer.Pause();
        } else {
            videoPlayer.Play();
        }
    }

    public void PlayNext() {
        videoPlayer.Stop();
        currentIndex = currentIndex+1;
        currentIndex %= videoClips.Length;
        Debug.Log("Index "+videoClips);
        VideoClip videoClip = videoClips[currentIndex];
        videoPlayer.clip = videoClip;
        videoPlayer.Play();
        Debug.Log("Now Playing "+ videoClip.name);
    }
}
