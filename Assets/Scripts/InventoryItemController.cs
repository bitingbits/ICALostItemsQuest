using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour {

    public GameSettings settings;
	public SoundController sc;
	public DialogController dc;

    public GameObject player;

	public AudioClip guitarAudioClip;
    public GameObject guitar;

	public AudioClip mugAudioClip;
    public GameObject mug;

	// Use this for initialization
	void Start () {
        settings.has_guitar = false;
        settings.has_mug = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (guitar != null)
            {
                if (Vector3.Distance(player.transform.position, guitar.transform.position) < 1f)
                {
                    settings.has_guitar = true;
                    Destroy(guitar);

					dc.ShowDialog (new string[] {"You found Niels' guitar!"});
					sc.PlaySound (guitarAudioClip);
                }
            }
            if (mug != null)
            {
                if (Vector3.Distance(player.transform.position, mug.transform.position) <=1f)
                {
                    settings.has_mug = true;
                    Destroy(mug);

					dc.ShowDialog (new string[] {"You found Jeff's mug!"});
					sc.PlaySound (mugAudioClip);
                }
            }
        }
        
	}



}

