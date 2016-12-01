using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour {

	public float dashFuel;
    public float moveSpeed;
	public float maxDash;
	public float minDash;
	public float baseMaxDash;
	public float dashBoost;
	//private float baseMoveSpeed = 6.0f;
    public Color[] colorlist;
    public int score;
    public TextMesh scoreText;
	public Text UIscoreText;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private int check;

    public GameObject gb;

	private AudioSource source;

	public float playerMovingWidth;
	public float playerMovingHeight;
	public float playerWidth;
	public float playerHeight;


	private float leftConstraint;
	private float rightConstraint;
	private float topConstraint;
	private float bottomConstraint;

    public float PlayerHealth = 100;
    public Text healthText;
    public ParticleSystem part;



    // Use this for initialization


    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        source = GetComponent<AudioSource>();
		Debug.Log (Screen.width);

		leftConstraint = Camera.main.ScreenToWorldPoint( new Vector2(0.0f, 0.0f) ).x;
		rightConstraint = Camera.main.ScreenToWorldPoint( new Vector2(Screen.width, 0.0f) ).x;
		topConstraint = Camera.main.ScreenToWorldPoint( new Vector2(0.0f, Screen.height) ).y;
		bottomConstraint = Camera.main.ScreenToWorldPoint( new Vector2(0.0f, 0.0f) ).y;

		dashFuel = 50f;

        PartUnFlash();
    }
	
	// Update is called once per frame
	void Update () 
		{

		if (score < 0) 
		{
			score = 0;
		} 

        // var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        // transform.position += move * moveSpeed * Time.deltaTime;

		if (Input.GetAxis ("Horizontal") > 0) {
			//set the velocity of the rigid body
			rb.velocity = new Vector2 (moveSpeed + dashBoost, rb.velocity.y);
			//rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			rb.transform.localScale = new Vector2 (playerMovingWidth, rb.transform.localScale.y); 
		} else {
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		}

        if (Input.GetAxis("Horizontal") < 0)
        {
            //set the velocity of the rigid body
            //rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
			rb.velocity = new Vector2(-moveSpeed - dashBoost, rb.velocity.y);
			rb.transform.localScale = new Vector2 (playerMovingWidth, rb.transform.localScale.y);

        } /*else {
			rb.transform.localScale = new Vector2 (1.0f, rb.transform.localScale.y); 
		}*/

        if (Input.GetAxis("Vertical") > 0)
        {
            //set the velocity of the rigid body
			rb.velocity = new Vector2(rb.velocity.x, moveSpeed + dashBoost);
			//rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
			rb.transform.localScale = new Vector2 (rb.transform.localScale.x, playerMovingHeight); 
		} else {
			rb.transform.localScale = new Vector2 (rb.transform.localScale.x, playerHeight); 
		}

        if (Input.GetAxis("Vertical") < 0)
        {
            //set the velocity of the rigid body
			rb.velocity = new Vector2(rb.velocity.x, -moveSpeed - dashBoost);
			//rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
			rb.transform.localScale = new Vector2 (rb.transform.localScale.x, playerMovingHeight); 
		} /*else {
			rb.transform.localScale = new Vector2 (rb.transform.localScale.x, 1.0f); 
		}*/

		//changes angle of the sprite depending on which directional keys are being pressed
		/*if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") > 0) {
			maxDash = maxDash * 0.5f;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, -45f);
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		} else {
			maxDash = baseMaxDash;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, 0f);		
		} 

		if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") > 0) {
			maxDash = maxDash * 0.5f;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, 45f);
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		} else {
			maxDash = baseMaxDash;
		}  

		if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") < 0) {
			maxDash = maxDash * 0.5f;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, -135f);
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		} 

		if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") < 0) {
			maxDash = maxDash * 0.5f;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, 135f);
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		}*/  

		if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") > 0) {
			maxDash = 50f;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, -45f);
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		} 
		else if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") > 0) 
		{
			maxDash = 50f;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, 45f);
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		}  

		else if (Input.GetAxis ("Vertical") > 0 && Input.GetAxis ("Horizontal") < 0) {
			maxDash = 50f;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, -135f);
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		} 

		else if (Input.GetAxis ("Vertical") < 0 && Input.GetAxis ("Horizontal") < 0) 
		{
			maxDash = 50f;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, 135f);
			rb.transform.localScale = new Vector2 (playerWidth, rb.transform.localScale.y); 
		} 
		else 
		{
			maxDash = baseMaxDash;
			rb.transform.localEulerAngles = new Vector3 (rb.transform.localRotation.x, rb.transform.localRotation.y, 0f);		
		} 


		//DASH ATTEMPT
		//float dashCounter = 0;

		if (/*Input.GetKey ("left shift") ||*/ Input.GetKey (KeyCode.Space) && dashFuel > 10f) {
			dashBoost += 1.0f;
			dashFuel -= 100f * Time.deltaTime;
			//dashCounter += Time.deltaTime;
		} else
		{
			dashBoost = minDash;
			dashFuel += 10f;
			//dashCounter = 0f;
		}

		dashFuel = Mathf.Clamp (dashFuel, 0f, 50f);

	

		//Mathf.Clamp(dashBoost, 

		//resetting player position when going past borders
		/*if (rb.transform.position.x > 3f) 
		{
			rb.transform.position = new Vector3 (-2.99f, rb.transform.position.y, rb.transform.position.z);
		}
		else if (rb.transform.position.x < -3f) 
		{
			rb.transform.position = new Vector3 (2.99f, rb.transform.position.y, rb.transform.position.z);
		}

		if (rb.transform.position.y > 2.81f)
		{
			rb.transform.position = new Vector3 (rb.transform.position.x, -7.70f, rb.transform.position.z);
		}
		else if (rb.transform.position.y < -7.71f)
		{
			rb.transform.position = new Vector3 (rb.transform.position.x, 2.80f, rb.transform.position.z);
		}*/

		//New system for any screen size
		if (rb.transform.position.x > rightConstraint) 
		{
			rb.transform.position = new Vector3 (leftConstraint, rb.transform.position.y, rb.transform.position.z);
		}
		else if (rb.transform.position.x < leftConstraint) 
		{
			rb.transform.position = new Vector3 (rightConstraint, rb.transform.position.y, rb.transform.position.z);
		}

		if (rb.transform.position.y > topConstraint)
		{
			rb.transform.position = new Vector3 (rb.transform.position.x, bottomConstraint, rb.transform.position.z);
		}
		else if (rb.transform.position.y < bottomConstraint)
		{
			rb.transform.position = new Vector3 (rb.transform.position.x, topConstraint, rb.transform.position.z);
		}

        //var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
		//Rigidbody2D rb = GetComponent<Rigidbody2D> ();

		//transform.position += move * moveSpeed * Time.deltaTime;

        //transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);

        scoreText.text = "Score: " + score.ToString();
		UIscoreText.text = "Score: " + score.ToString ();


		Color currentcolor = GetComponent<SpriteRenderer>().color;

		//CHANGES TRAIL COLOR TO MATCH PLAYER COLOR aka currentcolor
		if (currentcolor == colorlist [0]) 
		{
			transform.Find ("PinkTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("BlueTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("GreenTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("OrangeTrail").GetComponent<TrailRenderer> ().enabled = true;
		}

		else if (currentcolor == colorlist [1]) {
			transform.Find ("PinkTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("BlueTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("OrangeTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("GreenTrail").GetComponent<TrailRenderer> ().enabled = true;
		} else if (currentcolor == colorlist [2]) {
			transform.Find ("BlueTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("OrangeTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("GreenTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("PinkTrail").GetComponent<TrailRenderer> ().enabled = true;
		} else if (currentcolor == colorlist [3]) {
			transform.Find ("OrangeTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("GreenTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("PinkTrail").GetComponent<TrailRenderer> ().enabled = false;
			transform.Find ("BlueTrail").GetComponent<TrailRenderer> ().enabled = true;
    	}

        if(PlayerHealth <= 0)
		{
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Invoke("Restart", 2f);
		}

		healthText.text = "Health: " + PlayerHealth.ToString ("#");


       part.startColor = currentcolor;
		
		}

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collision");
        Color currentcolor = GetComponent<SpriteRenderer>().color;
        Debug.Log("now: " + currentcolor);

        Destroy(col.gameObject.GetComponent<CircleCollider2D>()); //can't collide with object twice

        //if (col.collider.tag == "bonus")
        //{
        //    score++;
        //}

        //pink orb

        PartFlash();
        Invoke("PartUnFlash", 0.5f);

       

		if (currentcolor == colorlist[0] && col.gameObject.tag == "Magenta"/*col.gameObject.name.Contains("orangeplatform")*/) //if orb is pink and hits pink platform
        {
			GameObject success = GameObject.Find ("SuccessSound"); 
			success.SendMessage ("RightColorSound"); //plays successful sound when in contact with correct color
			Debug.Log("orange on orange");
            score++;
            Debug.Log("score: " + score);
            while (check == 0)
            {
                check = Random.Range(0, 3);
            }
                GetComponent<SpriteRenderer>().color = colorlist[check];
           

            //green orb
        }
		else if (currentcolor == colorlist[1] && col.gameObject.tag == "Green" /*col.gameObject.name.Contains("greenplatform")*/)  //if orb is green and hits green platform
	        {
				GameObject success = GameObject.Find ("SuccessSound");
				success.SendMessage ("RightColorSound");
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

		else if (currentcolor == colorlist[2] && col.gameObject.tag == "Yellow"/*col.gameObject.name.Contains("pinkplatform")*/)  //if orb is orange and hits orange platform //pink should work now
	        {
				GameObject success = GameObject.Find ("SuccessSound");
				success.SendMessage ("RightColorSound");
				//Debug.Log("orange on orange");
	            score++;
	            Debug.Log("score: " + score);
            while (check == 2)
            {
                check = Random.Range(0, 3);
            }
            GetComponent<SpriteRenderer>().color = colorlist[check];
            
        }

	        //blue orb

		else if (currentcolor == colorlist[3] && col.gameObject.tag == "Yellow" /*col.gameObject.name.Contains("blueplatform")*/)  //if orb is blue and hits blue platform 
	        {
				GameObject success = GameObject.Find ("SuccessSound");
				success.SendMessage ("RightColorSound");
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
	            Debug.Log("hit");
                PlayerHealth-=10;
	            Debug.Log("score: " + score);
				source.Play();
	            col.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                ///GetComponent<SpriteRenderer>().color = Color.red;
        	}
			
	}
    void Restart()
    {
        SceneManager.LoadScene("main game");
    }


    void PartFlash()
    {
        part.startSize = 1;
    }

    void PartUnFlash()
    {
        part.startSize = 0;
    }
}
