using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get => _instance; }
    static SoundManager _instance;

    public enum SoundState
    {
        Sound1,
        Sound2,
        Sound3,
        None
    }
    public SoundState soundstate = SoundState.None;

    [SerializeField] private AudioSource audioSource;//AudioSource

    [SerializeField] AudioClip[] audioClips;
    //[SerializeField] private AudioClip audioClip1;//AudioClip
    //[SerializeField] private AudioClip audioClip2;
    //[SerializeField] private AudioClip audioClip3;


    private void Awake()
    {
        _instance = this;
        audioSource = GetComponent<AudioSource>();
    }


    public void Sound(SoundState state)
    {
        soundstate = state;
        switch (state)
        {
            case SoundState.Sound1:
                break;
            
        }
    }

    IEnumerator SE0()
    {
        audioSource.PlayOneShot(audioClips[0]);
        yield return null;
    }

    IEnumerator SE1()
    {
        audioSource.PlayOneShot(audioClips[1]);
        yield return null;
    }
    IEnumerator SE2()
    {
        audioSource.PlayOneShot(audioClips[2]);
        yield return null;
    }
  

}
