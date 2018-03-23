using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class GameSettings: ScriptableObject
{
	[SerializeField]
	public bool cutscene_done = false;

    [SerializeField]
    public bool has_mug = false;

    [SerializeField]
    public bool has_guitar = false;

}

