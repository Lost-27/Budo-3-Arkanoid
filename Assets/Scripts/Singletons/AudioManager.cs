using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : GeneralSingleton<AudioManager>
{
    #region Variables

    [SerializeField] private AudioSource _audioSource;

    #endregion
    

    #region Public methods

    public void PlayOnShot(AudioClip clip)
    {
        _audioSource.PlayOneShot(clip);
    }

    public void PlayBackground(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }

    #endregion
    
   
}