using UnityEngine;
using System.Collections;

public class PlayAudio : MonoBehaviour {
    
    [SerializeField]private AudioSource _audioSource;
    [SerializeField]private AudioClip _audioClip;

    public void PlaySound()
    {
        _audioSource.PlayOneShot(_audioClip);
    }
}
