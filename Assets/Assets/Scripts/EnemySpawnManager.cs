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

		randomSpawnTime = Random.Range (minSpawnTime, maxSpawnTime);
		enemySpawnTimer -= Time.deltaTime;

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
