using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealthManager : MonoBehaviour 
{

	// Use this for initialization
	public int playerHealth;
	public Text healthText;
    public TextMesh textOutput;

	void Start()
	{
		playerHealth = 100; 
	}

	void Update()
	{
		if(playerHealth <= 0)
		{
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Invoke("Restart", 1f);
		}

		//healthText.text = "Health: " + playerHealth.ToString ("#");


       // textOutput.text = healthText.text;

	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Meteor") 
		{
			playerHealth -= 34;
			Debug.Log ("Collision with meteor!");
		}
	}

    void Restart()
    {
        SceneManager.LoadScene("main game");
    }

	void HitByMeteor()
	{
		playerHealth -= 1;
	}
}

