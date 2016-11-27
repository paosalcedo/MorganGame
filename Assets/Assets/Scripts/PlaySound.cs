using UnityEngine;
using System.Collections;

// THIS IS ATTACHED TO THE EMPTY CHILD OF PLAYER "SuccessSound"
public class PlaySound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void RightColorSound()
	{
		AudioSource sound = GetComponent<AudioSource>();
		sound.Play ();
	}
}
