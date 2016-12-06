using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	// Use this for initialization
	SpriteRenderer gameOver;

	void Start () {
		gameOver = GetComponent<SpriteRenderer> ();
		//gameOver.GetComponent<SpriteRenderer>(enabled) = true;
	}
	
	// Update is called once per frame

	void GameOverMessageOn()
	{
		gameOver.enabled = true;
	}

	void GameOverMessageOff()
	{
		gameOver.enabled = false;
	}
}
