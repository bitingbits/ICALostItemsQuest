using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

	public GameSettings settings;

	public Text gameDialog;
	public string [] dialogContent;

	public SoundController sc;
	public AudioClip objectiveAudioClip;
	private string objectiveCue = "[OBJECTIVE]";

	int stringIndex = 0;
	int characterIndex = 0;

	void Start()
	{
		// STARTING INIT DIALOGUE
		if(settings.cutscene_done)
			StartCoroutine (DisplayAnimatedText());
	}
		
	IEnumerator DisplayAnimatedText()
	{
		while (stringIndex < dialogContent.Length)
		{
			// beginning a new string, could also put this in the skip func
			if (characterIndex == 1) {
				if (dialogContent [stringIndex].Contains (objectiveCue))
					sc.PlaySound(objectiveAudioClip);
			}
				
			// determines the speed at which text darts over the screen
			yield return new WaitForSeconds(0f);
			if (characterIndex > dialogContent[stringIndex].Length)
			{
				continue;
			}
			gameDialog.text = dialogContent[stringIndex].Substring(0, characterIndex);
			characterIndex++;
		}
	} 

	// Update is called once per frame 
	void Update (){
		SkipDialog ();
	}

	void ShowDialog(string [] dialogToDisplay){
		dialogContent = dialogToDisplay;
		stringIndex = 0;
		characterIndex = 0;
		StartCoroutine (DisplayAnimatedText());
	}

	void SkipDialog(){
		// TODO: SET TO GETBUTTONDOWN IN FINAL
		if (Input.GetKeyDown("e")) {
			if (stringIndex < dialogContent.Length - 1) {
				if (gameDialog.text == dialogContent [stringIndex]) {
					stringIndex++;
					characterIndex = 0;
				} else {
					gameDialog.text = dialogContent [stringIndex];
					characterIndex = dialogContent [stringIndex].Length;
				}
			} else {
				gameDialog.text = "";
			}
		}
	}


}﻿