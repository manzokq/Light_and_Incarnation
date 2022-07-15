using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEManager : MonoBehaviour
{
    public static SEManager Instance { get => _instance; }
    static SEManager _instance;

    public enum SoundState
    {
        Sound0,
        Sound1,
        Sound2,
        Sound3,
        Sound4,
        Sound5,
        Sound6,
        Sound7,
        Sound8,
        Sound9,
        Sound10,
        Sound11,
        Sound12,
        Sound13,
        Sound14,
        Sound15,
        None
    }

    public SoundState soundstate = SoundState.None;

    [SerializeField] private AudioSource audioSource;//AudioSource

    [SerializeField] AudioClip[] audioClips;
    private void Awake()
    {
        if (Instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
        audioSource = GetComponent<AudioSource>();

    }

    public void Sound(SoundState state)
    {
        soundstate = state;
        switch (state)
        {
            case SoundState.Sound0:
                audioSource.PlayOneShot(audioClips[0]);
                break;
            case SoundState.Sound1:
                audioSource.PlayOneShot(audioClips[1]);
                break;
            case SoundState.Sound2:
                audioSource.PlayOneShot(audioClips[2]);
                break;
            case SoundState.Sound3:
                audioSource.PlayOneShot(audioClips[3]);
                break;
            case SoundState.Sound4:
                audioSource.PlayOneShot(audioClips[4]);
                break;
            case SoundState.Sound5:
                audioSource.PlayOneShot(audioClips[5]);
                break;
            case SoundState.Sound6:
                audioSource.PlayOneShot(audioClips[6]);
                break;
            case SoundState.Sound7:
                audioSource.PlayOneShot(audioClips[7]);
                break;
            case SoundState.Sound8:
                audioSource.PlayOneShot(audioClips[8]);
                break;
            case SoundState.Sound9:
                audioSource.PlayOneShot(audioClips[9]);
                break;
            case SoundState.Sound10:
                audioSource.PlayOneShot(audioClips[10]);
                break;
            case SoundState.Sound11:
                audioSource.PlayOneShot(audioClips[11]);
                break;
            case SoundState.Sound12:
                audioSource.PlayOneShot(audioClips[12]);
                break;
            case SoundState.Sound13:
                audioSource.PlayOneShot(audioClips[13]);
                break;
            case SoundState.Sound14:
                audioSource.PlayOneShot(audioClips[14]);
                break;
            case SoundState.Sound15:
                audioSource.PlayOneShot(audioClips[15]);
                break;

        }
    }
}
