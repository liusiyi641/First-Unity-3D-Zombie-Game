using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheSound : MonoBehaviour {

	public AudioSource MusicSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			MusicSound.Play ();
		}
	}
}
