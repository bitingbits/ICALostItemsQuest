using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCanvasController : MonoBehaviour {

    public GameSettings settings;
    public Image guitar_image;
    public Image mug_image;

    public Sprite empty;
    public Sprite guitar;
    public Sprite mug;

	// Use this for initialization
	void Start () {
		guitar_image.sprite = empty;
		mug_image.sprite = empty;

		guitar_image.enabled = false;
		mug_image.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if (settings.cutscene_done) {
			guitar_image.enabled = true;
			mug_image.enabled = true;
		}

        if (settings.has_guitar == true)
        {
            guitar_image.sprite = guitar; 
        }
        if (settings.has_mug == true)
        {
            mug_image.sprite = mug;
        }
	}
}
