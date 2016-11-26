﻿using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {

    public float moveSpeed = 2;
    public Color[] colorlist;
    public int score;
    public TextMesh scoreText;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;

            scoreText.text = score.ToString();
        }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision");

        Color currentcolor = GetComponent<SpriteRenderer>().color;
        Debug.Log("now: " + currentcolor);

        //if (col.collider.tag == "bonus")
        //{
        //    score++;
        //}

        //pink orb

        if (currentcolor == colorlist[0] && col.gameObject.name.Contains("orangeplatform")) //if orb is pink and hits pink platform
        {
            Debug.Log("pink on pink");
            score++;
            Debug.Log("score: " + score);
            GetComponent<SpriteRenderer>().color = colorlist[Random.Range(0, 3)];
        }

   
        //green orb

        else if (currentcolor == colorlist[1] && col.gameObject.name.Contains("greenplatform"))  //if orb is green and hits green platform
        {
            Debug.Log("green on green");
            score++;
            Debug.Log("score: " + score);
            GetComponent<SpriteRenderer>().color = colorlist[Random.Range(0, 3)];
        }

        //orange orb

        else if (currentcolor == colorlist[2] && col.gameObject.name.Contains("pinkplatform"))  //if orb is orange and hits orange platform
        {
            Debug.Log("orange on orange");
            score++;
            Debug.Log("score: " + score);
            GetComponent<SpriteRenderer>().color = colorlist[Random.Range(0, 3)];
        }

        //blue orb

        else if (currentcolor == colorlist[3] && col.gameObject.name.Contains("blueplatform"))  //if orb is blue and hits blue platform
        {
            Debug.Log("blue on blue");
            score++;
            Debug.Log("score: " + score);
            GetComponent<SpriteRenderer>().color = colorlist[Random.Range(0, 3)];
        }

        else
        {
            Debug.Log("blue on orange");
            score -= 1;
            Debug.Log("score: " + score);
        }

    }
}
