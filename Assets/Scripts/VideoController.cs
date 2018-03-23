using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoController : MonoBehaviour {

	public GameSettings settings;

	public RawImage image;

	public VideoClip videoToPlay;
	public AudioClip videoAudio;

	private VideoPlayer videoPlayer;
	private VideoSource videoSource;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () {
		settings.cutscene_done = false;
		Application.runInBackground = true;
		StartCoroutine(playVideo());
	}

	void Update(){
		SkipVideo();
	}

	private void SkipVideo(){
		if (Input.GetKeyDown ("e")) {
			videoPlayer.Stop ();
			audioSource.Stop ();
			Destroy (image);
			settings.cutscene_done = true;
		}
	}

	private IEnumerator playVideo()
	{

		//Add VideoPlayer to the GameObject
		videoPlayer = gameObject.AddComponent<VideoPlayer>();

		//Add AudioSource
		audioSource = gameObject.AddComponent<AudioSource>();

		//Disable Play on Awake for both Video and Audio
		videoPlayer.playOnAwake = false;
		audioSource.playOnAwake = false;
		audioSource.Pause();

		videoPlayer.source = VideoSource.VideoClip;

		//Set Audio Output to AudioSource
		audioSource.clip = videoAudio;
		videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;

		//Assign the Audio from Video to AudioSource to be played
		videoPlayer.EnableAudioTrack(0, true);
		videoPlayer.SetTargetAudioSource(0, audioSource);

		//Set video To Play then prepare Audio to prevent Buffering
		videoPlayer.clip = videoToPlay;
		videoPlayer.Prepare();

		//Wait until video is prepared
		while (!videoPlayer.isPrepared)
		{
			yield return null;
		}

		Debug.Log("Done Preparing Video");

		//Assign the Texture from Video to RawImage to be displayed
		image.texture = videoPlayer.texture;

		//Play Video
		videoPlayer.Play();

		//Play Sound
		audioSource.Play();

		Debug.Log("Playing Video");
		while (videoPlayer.isPlaying)
		{
			Debug.LogWarning("Video Time: " + Mathf.FloorToInt((float)videoPlayer.time));
			yield return null;
		}

		Debug.Log("Done Playing Video");
		Destroy (image);

		// allow everything else to start
		settings.cutscene_done = true;
	}


}