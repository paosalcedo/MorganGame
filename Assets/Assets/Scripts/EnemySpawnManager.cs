using UnityEngine;
using System.Collections;

public class EnemySpawnManager : MonoBehaviour {

	// Use this for initialization
	public GameObject enemyPrefab;
	public float enemySpawnTimer;
	public float minSpawnTime;
	public float maxSpawnTime;
	float randomSpawnTime;
	//float ballSpawnMoveSpeed = 10f;

	float leftConstraint;
	float rightConstraint;
	float topConstraint;
	float bottomConstraint;
	float gameTime;
	public float spawnTimeDecay;

	//float randomPosX;
	// Use this for initialization
	void Start () {
		transform.position = new Vector2 (Random.Range (leftConstraint, rightConstraint), topConstraint+10f); 
		enemySpawnTimer = 0.0f;
		//Vector3 randomPos = transform.position;
		leftConstraint = Camera.main.ScreenToWorldPoint( new Vector2(0.0f, 0.0f) ).x;
		rightConstraint = Camera.main.ScreenToWorldPoint( new Vector2(Screen.width, 0.0f) ).x;
		topConstraint = Camera.main.ScreenToWorldPoint( new Vector2(0.0f, Screen.height) ).y;
		bottomConstraint = Camera.main.ScreenToWorldPoint( new Vector2(0.0f, 0.0f) ).y;

	}

	// Update is called once per frame
	void Update () {
		//gameTime += Time.deltaTime;
		randomSpawnTime = Random.Range (minSpawnTime, maxSpawnTime);
		enemySpawnTimer -= Time.deltaTime;


		if (minSpawnTime > 0.001f) 
		{
			minSpawnTime -= spawnTimeDecay * Time.deltaTime;
		} 
		else 
		{
			minSpawnTime = minSpawnTime;
		}

		if (maxSpawnTime > 0.002f) 
		{
			maxSpawnTime -= spawnTimeDecay * Time.deltaTime;
		} 
		else 
		{ 			
			maxSpawnTime = maxSpawnTime;
		}
		
		//Mathf.Clamp (minSpawnTime, 0.1f, 1f);
		//Mathf.Clamp (maxSpawnTime, 0.2f, 5f); 

		/*if (gameTime > 15 && gameTime < 30) 
		{
			minSpawnTime = 0.5f;
			maxSpawnTime = 2.5f;
		} 

		if (gameTime > 30 && gameTime < 45) 
		{
			minSpawnTime = 0.25f;
			maxSpawnTime = 1.25f;
		}

		if (gameTime > 45 && gameTime < 60) 
		{
			minSpawnTime = 0.125f;
			maxSpawnTime = 0.625f;
		}

		if (gameTime > 60) 
		{
			minSpawnTime = minSpawnTime/gameTime;
			maxSpawnTime = minSpawnTime;
		} */

		if (enemySpawnTimer <= 0) 
		{
			transform.position = new Vector2(Random.Range (leftConstraint, rightConstraint), topConstraint + 10f); 
			SpawnEnemy ();
			enemySpawnTimer = randomSpawnTime;
			Debug.Log ("Enemy spawned!");
		}  
	}

	void SpawnEnemy()
	{
		GameObject enemyClone = (GameObject)Instantiate (enemyPrefab, transform.position, Quaternion.identity);
	}
}
