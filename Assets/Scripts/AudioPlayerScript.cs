using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioClip[] audioClips;
    private int currentIndex;

    public AudioSource audioSource;

    void Awake() {
        currentIndex = 0;
    }

    void Start()
    {
        audioSource = audioSource.GetComponent<AudioSource>();
        AudioClip audioClip = audioClips[currentIndex];
        audioSource.clip = audioClip;
        audioSource.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            PlayNext();
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            PlayPause();
        }
        
    }

    public void PlayPause() {
        if(audioSource.isPlaying) {
            audioSource.Pause();
        } else {
            audioSource.Play();
        }
    }

    public void PlayNext() {
        audioSource.Stop();
        currentIndex = currentIndex+1;
        currentIndex %= audioClips.Length;
        Debug.Log("Index "+audioClips);
        AudioClip audioClip = audioClips[currentIndex];
        audioSource.clip = audioClip;
        audioSource.Play();
        Debug.Log("Now Playing "+ audioClip.name);
    }

    public void PlayAudio(string named) {

    }
}
