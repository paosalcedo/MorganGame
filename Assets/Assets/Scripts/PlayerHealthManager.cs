using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour 
{

	// Use this for initialization
	public int playerHealth;
	public Text healthText;

	void Start()
	{
		playerHealth = 100; 
	}

	void Update()
	{
		if(playerHealth <= 0)
		{
			SceneManager.LoadScene ("main game");
		}

		healthText.text = "Health: " + playerHealth.ToString ("#"); 


	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Meteor") 
		{
			playerHealth -= 34;
			Debug.Log ("Collision with meteor!");
		}
	}
}
