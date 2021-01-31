using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    //all the background music
    [SerializeField]
    Sound[] bgMusic;

    //all the sound effects
    [SerializeField]
    Sound[] soundEffects;

    //two different audio sources for bg and fx
    [SerializeField]
    AudioSource bgSource;

    [SerializeField]
    AudioSource[] fxSources;
    AudioSource fxSource;

    public static AudioManager Instance;//simpleton
    public static bool bgON = true;//volume adjustable from settings
    public static bool sfxON = true;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public void MuteSound()
    {
        MuteBGMusic();
        MuteSoundEffects();
    }

    public void UnMuteSound()
    {
        UnMuteBGMusic();
        UnMuteSoundEffects();
    }

    public void MuteBGMusic()
    {
        bgSource.volume = 0f;
        bgON = false;
    }

    public void UnMuteBGMusic()
    {
        bgSource.volume = 1f;
        bgON = true;
    }

    public void MuteSoundEffects()
    {
        foreach (AudioSource source in fxSources)
        {
            source.volume = 0f;
        }
        sfxON = false;
    }

    public void UnMuteSoundEffects()
    {
        foreach (AudioSource source in fxSources)
        {
            source.volume = 1f;
        }
        sfxON = true;
    }

    //find and play bg music using a string 
    public void PlayBGMusic(string name)
    {
        Sound s = new Sound();
        foreach (Sound sound in bgMusic)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        bgSource.clip = s.clip;
        bgSource.Play();
    }

    //this finds and plays a sound effect using the audio manager audio source. got a delay option as well
    public void PlaySoundEffect(string name, float delay = 0f)
    {
        Sound s = new Sound();
        foreach (Sound sound in soundEffects)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        foreach(AudioSource source in fxSources)
        {
            if(!source.isPlaying)
            {
                source.clip = s.clip;
                fxSource = source;
                Invoke("FXSourcePlay", delay);
                
                break;
            }
        }
       
    }

    void FXSourcePlay()
    {
        fxSource.Play();
    }

    public void ChangeSFXVolume(float volume)
    {
        foreach (var source in fxSources)
        {
            source.volume = volume;
        }
    }

    public void ChangeBGVolume(float volume)
    {
        bgSource.volume = volume;
    }

    //this returns the audio clip of a sound effect for other objects to play
    public AudioClip GetSoundEffect(string name)
    {
        Sound s = new Sound();
        foreach (Sound sound in soundEffects)
        {
            if (sound.name == name)
            {
                s = sound;
                break;
            }
        }
        if (s != null)
        {
            return s.clip;
        }
        else
        {
            return null;
        }
    }
}
