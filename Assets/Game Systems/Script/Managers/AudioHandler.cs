using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioHandler : MonoBehaviour
{
    private static AudioHandler _audioHandler;

    public AudioSource audioSFX;
    public AudioClip[] audioClips;

    public static AudioHandler AudioHandlerInstance
    {
        get { return _audioHandler; }
        //get =>  _audioHandler;
            private set
            {
                if (_audioHandler == null)
                {
                    _audioHandler = value;
                }
                else if (_audioHandler != value)
                {
                    Debug.Log($"{nameof(GameManager)} instance already exists, destroy the other THERE CAN ONLY BE ONE");
                    Destroy(value);
                }
            }
    }

    public AudioMixer masterAudio;
    private string _slider;

    public void SelectSlider(string slider)
    {
        _slider = slider;
    }
    public void ChangeVolume(float volume)
    {
        masterAudio.SetFloat(_slider, volume);
    }

    public void PlayClip()
    {
        int clip = Random.Range(0, audioClips.Length);
        audioSFX.clip = audioClips[clip];
        audioSFX.Play();
    }
}
