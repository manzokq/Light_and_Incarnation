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
                audioSource.PlayOneShot(audioClips[0]);
                break;
            case SoundState.Sound2:
                audioSource.PlayOneShot(audioClips[1]);
                break;
            case SoundState.Sound3:
                audioSource.PlayOneShot(audioClips[2]);
                break;

        }
    }
}
