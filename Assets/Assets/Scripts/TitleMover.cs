using UnityEngine;
using System.Collections;

public class TitleMover : MonoBehaviour {

	Transform titleTr;
	public float textScrollSpeed;

	// Use this for initialization
	void Start () {
		titleTr = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.down * textScrollSpeed * Time.deltaTime);
	}
}
