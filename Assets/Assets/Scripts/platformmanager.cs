﻿using UnityEngine;
using System.Collections;


public class platformmanager : MonoBehaviour
{
    public GameObject pinkplatformPrefab;
    public GameObject greenplatformPrefab;
    public GameObject blueplatformPrefab;
    public GameObject orangeplatformPrefab;

    public Vector3[] spawnPositions;
    public Vector3[] rightspawnPositions;
    public float timeUntilSpawn = 0;
    public float timeBetweenSpawns = 1;
    public float xSpawnPos;
    //public float ySpawnPosMin;
    //public float ySpawnPosMax;




    void SpawnPlatform()
    {
        int i = Random.Range(0, spawnPositions.Length);//a number between 0 and the number of spawn positions (exclusive)
        float side = Random.Range(0f, 1f); //what side it's gonna spawn on

        //Debug.Log("side spawn " + side);

        //Debug.Log("current spawnType -> " + i);
        Vector3 spawnPosition = spawnPositions[i]; //get the actual position we stored in the inspector
        Vector3 rightspawnPosition = rightspawnPositions[i];

       
        if (i == 0)
        {
            

            if (side < 0.5) //spawn on left
            {
                
                 GameObject pinkplatform = Instantiate(pinkplatformPrefab, spawnPosition, Quaternion.identity) as GameObject;
                 pinkplatform.transform.position = new Vector3(
                 spawnPosition.x,
                 spawnPosition.y,
                 spawnPosition.z);

            }

            else //spawn on right
            {
                 GameObject pinkplatform = Instantiate(pinkplatformPrefab, rightspawnPosition, Quaternion.identity) as GameObject;
                 pinkplatform.transform.position = new Vector3(
                 rightspawnPosition.x,
                 rightspawnPosition.y,
                 rightspawnPosition.z);

                pinkplatform.GetComponent<SpriteRenderer>().flipX = true;
                //transform.Rotate(new Vector3(0, 180, 0));

            }
        }

        else if (i == 1)
        {
            if (side < 0.5)
            {
                GameObject blueplatform = Instantiate(blueplatformPrefab, spawnPosition, Quaternion.identity) as GameObject;
                blueplatform.transform.position = new Vector3(
                spawnPosition.x,
                spawnPosition.y,
                spawnPosition.z);
            }

            else
            {
                GameObject blueplatform = Instantiate(blueplatformPrefab, rightspawnPosition, Quaternion.identity) as GameObject;
                blueplatform.transform.position = new Vector3(
                rightspawnPosition.x,
                rightspawnPosition.y,
                rightspawnPosition.z);

                blueplatform.GetComponent<SpriteRenderer>().flipX = true;
            }
            
        }

        else if (i == 2)
        {

            if (side < 0.5)
            { 
               GameObject orangeplatform = Instantiate(orangeplatformPrefab, spawnPosition, Quaternion.identity) as GameObject;
               orangeplatform.transform.position = new Vector3(
               spawnPosition.x,
               spawnPosition.y,
               spawnPosition.z);
            } 

            else
            {
                GameObject orangeplatform = Instantiate(orangeplatformPrefab, rightspawnPosition, Quaternion.identity) as GameObject;
                orangeplatform.transform.position = new Vector3(
                rightspawnPosition.x,
                rightspawnPosition.y,
                rightspawnPosition.z);

                orangeplatform.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

        else if (i == 3)
        {
            if (side < 0.5)
            { 
               GameObject greenplatform = Instantiate(greenplatformPrefab, spawnPosition, Quaternion.identity) as GameObject;
               greenplatform.transform.position = new Vector3(
               spawnPosition.x,
               spawnPosition.y,
               spawnPosition.z);
            }

            else
            {
                GameObject greenplatform = Instantiate(greenplatformPrefab, rightspawnPosition, Quaternion.identity) as GameObject;
                greenplatform.transform.position = new Vector3(
                rightspawnPosition.x,
                rightspawnPosition.y,
                rightspawnPosition.z);

                greenplatform.GetComponent<SpriteRenderer>().flipX = true;
            }
        }

       

    }

    

    public void Update()
    {
        //Time.delaTime is how much time has occured since the last update. 
        //We subtract it from time until spawn every frame
        timeUntilSpawn -= Time.deltaTime;
        //Once timeUntilSpawn is less than 0, we spawn a new hat
        if (timeUntilSpawn <= 0)
        {
            SpawnPlatform();
            //then we reset timeUntilSpawn to the timeBetweenSpawns & start all over again
            timeUntilSpawn = timeBetweenSpawns;
        }

    }
}