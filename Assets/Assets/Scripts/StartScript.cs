using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Return)) 
		{
			SceneManager.LoadScene ("main game", LoadSceneMode.Single);
		}

		if (Input.GetKey("escape"))
		{
			Application.Quit();	
		}
	}
}
