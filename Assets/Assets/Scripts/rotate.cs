﻿using UnityEngine;
using System.Collections;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       transform.Rotate(new Vector3(0, 50 * Time.deltaTime, 0));

        //Physics2D.gravity.y(Time.deltaTime * 10);

        
    }
}
