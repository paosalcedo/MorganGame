﻿using UnityEngine;
using System.Collections;

public class CamShakeSimple : MonoBehaviour
{

    public Vector3 originalCameraPosition;

    float shakeAmt = 0;

    public Camera mainCamera;

    public Rigidbody2D rb;
    public float moveSpeed;
    public float speedMultiplier;


    void OnCollisionEnter2D(Collision2D coll)
    {

        //shakeAmt = coll.relativeVelocity.magnitude * .025f;
		shakeAmt = coll.relativeVelocity.magnitude * .005f;
		InvokeRepeating("CameraShake", 0, .01f);
        Invoke("StopShaking", 0.3f);

       /* if (Input.GetAxis("Horizontal") > 0)
        {
            //set the velocity of the rigid body
            rb.velocity = new Vector2(moveSpeed * speedMultiplier, rb.velocity.y);
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            //set the velocity of the rigid body
            rb.velocity = new Vector2(-moveSpeed * speedMultiplier, rb.velocity.y);
        }
        if (Input.GetAxis("Vertical") > 0)
        {
            //set the velocity of the rigid body
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed * speedMultiplier);
        }
        if (Input.GetAxis("Vertical") < 0)
        {
            //set the velocity of the rigid body
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed * speedMultiplier);
        }*/

    }

    void CameraShake()
    {
        if (shakeAmt > 0)
        {
            float quakeAmt = Random.value * shakeAmt * 2 - shakeAmt;
            Vector3 pp = mainCamera.transform.position;
            pp.x += quakeAmt; // can also add to x and/or z
            mainCamera.transform.position = pp;
        }
    }

    void StopShaking()
    {
        CancelInvoke("CameraShake");
        mainCamera.transform.position = originalCameraPosition;
    }

}
