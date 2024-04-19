using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class music_manager : MonoBehaviour
{
    [SerializeField] private AudioClip[] musicArray;

    [SerializeField] private Sprite[] musicImages;

    [SerializeField] private Button Play;
    [SerializeField] private Button Pause;
    [SerializeField] private Button Loop;
    [SerializeField] private Button Shufle;
    [SerializeField] private Button Next;
    [SerializeField] private Button Previous;
    [SerializeField] private Button Stop;
    

    [SerializeField] private Image imagePlace;

    [SerializeField] private AudioSource audio;

    private bool isLooping = false;

    private int currentTrackIndex = 0;


    public void Start()
    {
        Play.onClick.AddListener(PlayMusic);
        Pause.onClick.AddListener(PauseMusic);
        Next.onClick.AddListener(PlayNextTrack);
        Previous.onClick.AddListener(PlayPreviousTrack);
        Stop.onClick.AddListener(StopMusic);
        Shufle.onClick.AddListener(PlayRandomTrack);
        Loop.onClick.AddListener(ToggleLoop);
        
        audio.loop = false;
        audio.clip = musicArray[currentTrackIndex];
        audio.Play();
        audio.loop = isLooping; 
        audio.loop = false;
        

        audio.clip = musicArray[0];
    }

    void Update()
    {
        if (!audio.isPlaying && !isLooping)
        {
            PlayNextTrack();
        }
    }

    public void PlayMusic()
    {
        audio.Play();
    }

    public void PauseMusic()
    
    {
        audio.Pause();
    }

    public void PlayNextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicArray.Length;
        audio.clip = musicArray[currentTrackIndex];
        audio.Play();
    }

    public void PlayPreviousTrack()
    {
        currentTrackIndex = (currentTrackIndex - 1 + musicArray.Length) % musicArray.Length;
        audio.clip = musicArray[currentTrackIndex];
        audio.Play();
    }

    void StopMusic()
    {
        audio.Stop();
    }

    void PlayRandomTrack()
    {
        int randomIndex = Random.Range(0, musicArray.Length);
        audio.clip = musicArray[randomIndex];
        audio.Play();
    }
    
    void ToggleLoop()
    {
        isLooping = !isLooping;
        audio.loop = isLooping;
    }
    
  

}
