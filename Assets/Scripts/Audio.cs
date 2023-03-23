using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : Singleton<Audio>
{
    [Header("Main Setting:")]
    [Range(0f, 1f)]
    public float musicVolume;
    [Range(0f, 1f)]
    public float sfxVolume;

    public AudioSource musicAus;
    public AudioSource sfxAus;

    [SerializeField] Image On;
    [SerializeField] Image Off;
    private bool muted = false;

    [Header("Game Sound And Musics:")]
    public AudioClip shooting;
    public AudioClip bgmusics;

    public void Update()
    {
        if (!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButonIcon();
        AudioListener.pause = muted;
    }
    public override void Awake()
    {
        PlayMusic(bgmusics);
        
       
    }
    //void Awake()
    //{
    //    if (!PlayerPrefs.HasKey("muted"))
    //    {
    //        PlayerPrefs.SetInt("muted", 0);
    //        Load();
    //    }
    //    else
    //    {
    //        Load();
    //    }
    //    UpdateButonIcon();
    //    AudioListener.pause = muted;
    //}

    public void OnButtonPress()
    {
        if (muted == false)
        {
            muted = true;
            AudioListener.pause = true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButonIcon();
    }
    private void UpdateButonIcon()
    {
        if (muted == false)
        {
            On.enabled = true;
            Off.enabled = false;
        }

        else
        {
            On.enabled = false;
            Off.enabled = true;
        }
    }
    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
    }
    public void PlaySound(AudioClip sound, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }

        if (aus)
        {
            aus.PlayOneShot(sound, sfxVolume);
        }
    }

    //public void PlaySound(AudioClip[] sounds, AudioSource aus = null)
    //{
    //    if (!aus)
    //    {
    //        aus = sfxAus;
    //    }

    //    if (aus)
    //    {
    //        int randIdx =  Random.Range(0, sounds.Length);
    //        if (sounds[randIdx] != null)
    //        {
    //            aus.PlayOneShot(sounds[randIdx], sfxVolume);
    //        }
    //    }
    //}

    public void PlayMusic(AudioClip music, bool loop = true)
    {
        if (musicAus)
        {
            musicAus.clip = music;
            musicAus.loop = loop;
            musicAus.volume = musicVolume;
            musicAus.Play();    
        }
    }

    //public void PlayMusic(AudioClip[] musics, bool loop = true )
    //{
    //    if (musicAus)
    //    {
    //        int randIdx  =  Random.Range(0, musics.Length); 
    //        if (musics[randIdx] != null)
    //        {
    //            musicAus.clip = musics[randIdx];
    //            musicAus.loop = loop;
    //            musicAus.volume = musicVolume;
    //            musicAus.Play();
    //        }
    //    }
    //}
   

}
