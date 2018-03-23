﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour {

    public GameSettings settings;
    public GameObject player;
    public GameObject guitar;
    public GameObject mug;

	// Use this for initialization
	void Start () {
		if (settings == null)
        {
            settings = ScriptableObject.CreateInstance<GameSettings>();
        }

	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log("pick up");
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Vector3.Distance(player.transform.position, guitar.transform.position) < 1f)
            {
                settings.has_guitar = true;
                Destroy(guitar);
            }
            else if (Vector3.Distance(player.transform.position, mug.transform.position) <=1f)
            {
                settings.has_mug = true;
                Destroy(mug);
            }
        }
        
	}



}

