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
		if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<GameSettings>();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
        if (settings.has_guitar == true)
        {
            guitar_image.sprite = guitar; 
        }
        else if (settings.has_mug == true)
        {
            mug_image.sprite = mug;
        }
        else
        {
            guitar_image.sprite = empty;
            mug_image.sprite = empty;
        }

	}
}
