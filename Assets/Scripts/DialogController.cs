using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour {

	public Text gameDialog;
	public string [] dialogContent;

	int stringIndex = 0;
	int characterIndex = 0;

	void Start()
	{
		// STARTING INIT DIALOGUE
		StartCoroutine (DisplayAnimatedText());
	}

	// TODO: Play sound effect for objective if a string contains '[Objective]'
	IEnumerator DisplayAnimatedText()
	{
		while (stringIndex < dialogContent.Length)
		{
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
		// TODO: SET TO GETBUTTONDOWN IN FINAL
		if (Input.GetKeyDown("e")) {
			if (stringIndex < dialogContent.Length) {
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

	void ShowDialog(string [] dialogToDisplay){
		dialogContent = dialogToDisplay;
		stringIndex = 0;
		characterIndex = 0;
		StartCoroutine (DisplayAnimatedText());
	}


}﻿