//using UnityEngine;
//using System.Collections;

//public class bonusmanager : MonoBehaviour
//{
//    public GameObject bonusPrefab;

//    public float timeBetweenSpawns = 1;
//    public float timeUntilSpawn = 0;

//    public float xSpawnPosMin; //left most spawn point
//    public float xSpawnPosMax; //right most spawn point
//    public float ySpawnPos;

//    void spawnbonus()
//    {
//        Debug.Log("spawned bonus");

//        Vector2 newPos = new Vector3(Random.Range(xSpawnPosMin, xSpawnPosMax), ySpawnPos, 0);

//        Instantiate(bonusPrefab, newPos, Quaternion.identity);
//    }

//    public void Update()
//    {
//        //Time.delaTime is how much time has occured since the last update. 
//        //We subtract it from time until spawn every frame
//        timeUntilSpawn -= Time.deltaTime;
//        //Once timeUntilSpawn is less than 0, we spawn a new hat
//        if (timeUntilSpawn <= 0)
//        {
//            spawnbonus();
//            //then we reset timeUntilSpawn to the timeBetweenSpawns & start all over again
//            timeUntilSpawn = timeBetweenSpawns;
//        }
//    }


//}
