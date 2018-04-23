using UnityEngine;

public class AudioManager : MonoBehaviour {

    // need to set up audio groups 
    public static AudioManager instance = null;
    public float sfxVolume = 1.0f;
    public AudioSource audioControl;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }    
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }     
    }

    public void SwapMusic( AudioClip music)
    {
        // stops current music track
        audioControl.Stop();
        // replaces current loaded track with new track supplied in the parameter
        audioControl.clip = music;
        // start the music playing again
        audioControl.Play();
    }

    public void SetSoundFXVolume(float newVolume)
    {
        sfxVolume = newVolume;
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioControl.volume = musicVolume;
    }
}
