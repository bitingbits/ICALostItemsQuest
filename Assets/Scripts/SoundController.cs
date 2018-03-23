using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	/**
	 * Takes a clip and plays it with through the general audiosource.
	 * Also takes an option volume param which should be between 0.0 and 1.0
	 **/
	private void PlaySound(AudioClip clipToPlay, float volume = 1f)
	{
		audioSource.volume = volume;
		audioSource.PlayOneShot(clipToPlay);
	}
}
