using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayBackgroundMusic : MonoBehaviour {

    [SerializeField]private List<AudioClip> _songs = new List<AudioClip>();
    private AudioSource _audioSource;
	// Use this for initialization
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        PlaySoundtrack();
    }

    void PlaySoundtrack()
    {
        if (!_audioSource.isPlaying)
        {
            _audioSource.clip = _songs[Random.Range(0, _songs.Count)];
            _audioSource.Play();
        }
    }
}
