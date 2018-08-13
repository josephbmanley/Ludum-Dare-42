using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntercomManager : MonoBehaviour {
    public List<AudioClip> messages;
    const float countDownMax = 45f;
    const float countDownMin = 10f;
    float currentCountDown;
    AudioSource source;
	// Use this for initialization
	void Start () {
        currentCountDown = countDownMin;
        source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if(source.isPlaying == false)
        {
            currentCountDown -= Time.deltaTime;
            if(currentCountDown <= 0)
            {
                source.clip = messages[Random.Range(0, messages.Count)];
                source.Play();
                currentCountDown = Random.Range(countDownMin, countDownMax);
            }
        }
	}
}
