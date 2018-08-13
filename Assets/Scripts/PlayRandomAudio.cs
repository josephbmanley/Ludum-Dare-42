using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayRandomAudio : MonoBehaviour {
    public List<AudioClip> clips;

	void Start () {
        AudioSource source = GetComponent<AudioSource>();
        source.clip = clips[Random.Range(0, clips.Count)];
        source.Play();
	}
	
}
