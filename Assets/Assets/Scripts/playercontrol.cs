using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {

    public float moveSpeed = 2;
    public Color[] colorlist;
    public int score;
    public TextMesh scoreText;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private int check;

  


    // Use this for initialization


	void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () 
		{

        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * moveSpeed * Time.deltaTime;

        transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);

        scoreText.text = score.ToString();

		Color currentcolor = GetComponent<SpriteRenderer>().color;

		//CHANGES TRAIL COLOR TO MATCH PLAYER COLOR aka currentcolor
		if (currentcolor == colorlist [0]) 
		{
			transform.Find ("PinkTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("BlueTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("GreenTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("OrangeTrail").GetComponent<TrailRenderer> ().enabled = true;
			Debug.Log ("Trail is now Orange!");
		}

		else if (currentcolor == colorlist [1]) {
			transform.Find ("PinkTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("BlueTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("OrangeTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("GreenTrail").GetComponent<TrailRenderer> ().enabled = true;
			Debug.Log ("Trail is now Green!");
		} else if (currentcolor == colorlist [2]) {
			transform.Find ("BlueTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("OrangeTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("GreenTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("PinkTrail").GetComponent<TrailRenderer> ().enabled = true;
			Debug.Log ("Trail is now Pink!");
		} else if (currentcolor == colorlist [3]) {
			transform.Find ("OrangeTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("GreenTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("PinkTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("BlueTrail").GetComponent<TrailRenderer> ().enabled = true;
			Debug.Log ("Trail is now Blue!");
    	}
		
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
            while (check == 0)
            {
                check = Random.Range(0, 3);
            }
                GetComponent<SpriteRenderer>().color = colorlist[check];
           

            //green orb
        }
        	else if (currentcolor == colorlist[1] && col.gameObject.name.Contains("greenplatform"))  //if orb is green and hits green platform
	        {
	            Debug.Log("green on green");
	            score++;
	            Debug.Log("score: " + score);

            while (check == 1)
            {
                check = Random.Range(0, 3);
            }
                GetComponent<SpriteRenderer>().color = colorlist[check];
            

	        }

	        //orange orb

	        else if (currentcolor == colorlist[2] && col.gameObject.name.Contains("pinkplatform"))  //if orb is orange and hits orange platform //pink should work now
	        {
	            Debug.Log("orange on orange");
	            score++;
	            Debug.Log("score: " + score);
            while (check == 2)
            {
                check = Random.Range(0, 3);
            }
            GetComponent<SpriteRenderer>().color = colorlist[check];
            
        }

	        //blue orb

	        else if (currentcolor == colorlist[3] && col.gameObject.name.Contains("blueplatform"))  //if orb is blue and hits blue platform 
	        {
	            Debug.Log("blue on blue");
	            score++;
	            Debug.Log("score: " + score);
            while (check == 3)
            {
                check = Random.Range(0, 3);
            }
            GetComponent<SpriteRenderer>().color = colorlist[check];
        }

	        else
	        {
	            Debug.Log("blue on orange");
	            score -= 1;
	            Debug.Log("score: " + score);
	        }
			
	}

}
