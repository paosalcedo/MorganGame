using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour {

	int newCheck;
	int oldCheck;
	private int colorChangeCounter;
	public float dashFuel;
    public float moveSpeed;
	public float maxDash;
	public float minDash;
	public float baseMaxDash;
	public float dashBoost;
    private float comboScore;
	//private float baseMoveSpeed = 6.0f;
    public Color[] colorlist;
    private int score;
    public TextMesh scoreText;
	public Text UIscoreText;
    public Text comboText;
    public Text colorChangeText;
	public bool noKeysPressed;

    private Rigidbody2D rb;
    private SpriteRenderer sr;


    private int check;
    private float colorChangeIncrementer; //int that gives a color change every three streak

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

    private float scoreTimer;

	GameObject pinkTrail;
	GameObject blueTrail;
	GameObject greenTrail;
	GameObject orangeTrail;
	TrailRenderer pinktr;
	TrailRenderer bluetr;
	TrailRenderer greentr;
	TrailRenderer orangetr;


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

		pinkTrail = GameObject.Find ("PinkTrail");
		blueTrail = GameObject.Find ("BlueTrail");
		greenTrail = GameObject.Find ("GreenTrail");
		orangeTrail = GameObject.Find ("OrangeTrail");
		pinktr = pinkTrail.GetComponent<TrailRenderer> ();
		bluetr = blueTrail.GetComponent<TrailRenderer> ();
		greentr = greenTrail.GetComponent<TrailRenderer> ();
		orangetr = orangeTrail.GetComponent<TrailRenderer> ();

		newCheck = 0;
		oldCheck = 0;

        PartUnFlash();

        scoreTimer = 10f;
    }

    // Update is called once per frame
    void Update()
    {
		//score can't go below 0
        if (score < 0)
        {
            score = 0;
        }

        // var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        // transform.position += move * moveSpeed * Time.deltaTime;

		//PLAYER MOVEMENT SECTION
		noKeysPressed = true;

		if (noKeysPressed == true)
		{
			maxDash = baseMaxDash; 
			rb.transform.localScale = new Vector2(playerWidth, playerHeight);
			//rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, 0f);
		}

        if (Input.GetAxis("Horizontal") > 0) //RIGHT
        {
			noKeysPressed = false;
            //set the velocity of the rigid body
            rb.velocity = new Vector2(moveSpeed + dashBoost, rb.velocity.y);
            //rb.velocity = new Vector2 (moveSpeed, rb.velocity.y);
			rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
			rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, -90f);
		} /*else
		{
			maxDash = baseMaxDash; 
			//rb.transform.localScale = new Vector2(playerWidth, playerHeight);
			//rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, 0f);
		}*/

      
        if (Input.GetAxis("Horizontal") < 0) //LEFT
        {
			noKeysPressed = false;
            //set the velocity of the rigid body
            //rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
            rb.velocity = new Vector2(-moveSpeed - dashBoost, rb.velocity.y);
			rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
			rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, 90f); 
			//rb.transform.rotation = new Vector3 (rb.transform.rotation.x, rb.transform.rotation.y, -90f);
			//rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
		} 

			
        if (Input.GetAxis("Vertical") > 0) //UP
        {
			noKeysPressed = false;
            //set the velocity of the rigid body
			rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, 0f); 
            rb.velocity = new Vector2(rb.velocity.x, moveSpeed + dashBoost);
            //rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
			rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
		} 


        if (Input.GetAxis("Vertical") < 0) //DOWN
        {
			noKeysPressed = false;
            //set the velocity of the rigid body
            rb.velocity = new Vector2(rb.velocity.x, -moveSpeed - dashBoost);
            //rb.velocity = new Vector2(rb.velocity.x, -moveSpeed);
			rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, 180f); 
			rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
		} 

			
        //changes angle of the sprite depending on which directional keys are being pressed

        if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") > 0) //Moving UP + RIGHT
        {
			noKeysPressed = false;
            maxDash = 50f;
            rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, -45f);
			rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
        }
        


		if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") > 0) //DOWN + RIGHT
        {
			noKeysPressed = false;
            maxDash = 50f;
            rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, -135f);
			rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
        }

	

		if (Input.GetAxis("Vertical") > 0 && Input.GetAxis("Horizontal") < 0) //UP + LEFT
		{
			noKeysPressed = false;
            maxDash = 50f;
            rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, 45f);
			rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
        }



        if (Input.GetAxis("Vertical") < 0 && Input.GetAxis("Horizontal") < 0) //DOWN + LEFT
        {
			noKeysPressed = false;
			maxDash = 50f;
            rb.transform.localEulerAngles = new Vector3(rb.transform.localRotation.x, rb.transform.localRotation.y, -225f);
			rb.transform.localScale = new Vector2(playerWidth, playerMovingHeight);
        }		
			


		//maxDash = baseMaxDash;


		//rb.transform.localScale = new Vector2(playerWidth, playerHeight);

        //DASH ATTEMPT
        //float dashCounter = 0;
        GameObject dashSound = GameObject.Find("Dash Sound");
        AudioSource dash = dashSound.GetComponent<AudioSource>();

        if (Input.GetKey(KeyCode.Space) && dashFuel > 10f)
        {
            dashBoost += 1.0f;
            dashFuel -= 100f * Time.deltaTime;
            dash.Play();
            //source.Play ();

        }
        else
        {
            dashBoost = minDash;
            dashFuel += 10f;

        }

        dashFuel = Mathf.Clamp(dashFuel, 0f, 50f);



        //Mathf.Clamp(dashBoost, 

        //Original screen wrap
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

        //Screen wrap 
        if (rb.transform.position.x > rightConstraint)
        {
            TrailWrap();
            rb.transform.position = new Vector3(leftConstraint, rb.transform.position.y, rb.transform.position.z);

        }
        else if (rb.transform.position.x < leftConstraint)
        {
            TrailWrap();
            rb.transform.position = new Vector3(rightConstraint, rb.transform.position.y, rb.transform.position.z);

        }

        if (rb.transform.position.y > topConstraint)
        {
            TrailWrap();
            rb.transform.position = new Vector3(rb.transform.position.x, bottomConstraint, rb.transform.position.z);
        }
        else if (rb.transform.position.y < bottomConstraint)
        {
            TrailWrap();
            rb.transform.position = new Vector3(rb.transform.position.x, topConstraint, rb.transform.position.z);
        }

        //var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        //Rigidbody2D rb = GetComponent<Rigidbody2D> ();

        //transform.position += move * moveSpeed * Time.deltaTime;

        //transform.Translate(Input.acceleration.x, 0, -Input.acceleration.z);

        scoreText.text = "Score: " + score.ToString();
        UIscoreText.text = "Score: " + score.ToString();
        comboText.text = "Streak: " + comboScore.ToString();
        colorChangeText.text = "Changes: " + colorChangeCounter.ToString();



        Color currentcolor = GetComponent<SpriteRenderer>().color;

        //CHANGES TRAIL COLOR TO MATCH PLAYER COLOR aka currentcolor
        if (currentcolor == colorlist[0])
        {
            pinktr.enabled = false;
            bluetr.enabled = false;
            greentr.enabled = false;
            orangetr.enabled = true;
        }

        else if (currentcolor == colorlist[1])
        {
            pinktr.enabled = false;
            bluetr.enabled = false;
            greentr.enabled = true;
            orangetr.enabled = false;

        }
        else if (currentcolor == colorlist[2])
        {
            pinktr.enabled = true;
            bluetr.enabled = false;
            greentr.enabled = false;
            orangetr.enabled = false;
        }
        else if (currentcolor == colorlist[3])
        {
            pinktr.enabled = false;
            bluetr.enabled = true;
            greentr.enabled = false;
            orangetr.enabled = false;
        }

        if (PlayerHealth <= 0)
        {
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Invoke("Restart", 2f);
        }

        healthText.text = "Health: " + PlayerHealth.ToString("#");


        part.startColor = currentcolor;

		//COLOR CHANGER


		if (Input.GetButtonDown("Fire1") && colorChangeCounter > 0 )
		{
			while (newCheck == oldCheck) 
			{
				newCheck = Random.Range (0, 4);//wtf?
			}

			GetComponent<SpriteRenderer>().color = colorlist[newCheck];
			oldCheck = newCheck;
			Debug.Log ("Color is now " + newCheck);
            colorChangeCounter--;
            colorChangeIncrementer = 0;
        }

        scoreTimer -= Time.deltaTime;
        if (scoreTimer <= 0f)
        {
            colorChangeCounter += 1;
            scoreTimer += 10f;
        }

        if (colorChangeIncrementer > 3)
        {
            colorChangeIncrementer = 0;
            Debug.Log(colorChangeIncrementer);
        }

        if (colorChangeCounter < 1 && colorChangeIncrementer > 2)
        {
            colorChangeCounter += 1;
            
        }

        /*if(colorChangeCounter ==0 && comboScore >2)
        {
            colorChangeCounter++;
        }*/

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
            comboScore++;
            colorChangeIncrementer++;
            Debug.Log("score: " + score);
            while (check == 0)
            {
                check = Random.Range(0, 4);
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
                comboScore++;
                colorChangeIncrementer++;
                Debug.Log("score: " + score);

            while (check == 1)
            {
                check = Random.Range(0, 4);
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
                comboScore++;
                colorChangeIncrementer++;
                Debug.Log("score: " + score);
            while (check == 2)
            {
                check = Random.Range(0, 4);
            }
            GetComponent<SpriteRenderer>().color = colorlist[check];
            
        }

	        //blue orb

		else if (currentcolor == colorlist[3] && col.gameObject.tag == "Blue" /*col.gameObject.name.Contains("blueplatform")*/)  //if orb is blue and hits blue platform 
	        {
				GameObject success = GameObject.Find ("SuccessSound");
				success.SendMessage ("RightColorSound");
	            Debug.Log("blue on blue");
                score++;
                comboScore++;
                colorChangeIncrementer++;
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
                comboScore=0;
                colorChangeIncrementer=0;
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
        part.startSize = 15;
        part.startSpeed = 10;
    }

    void PartUnFlash()
    {
        part.startSize = 0;
    }


	//Sets trail time back to 1.
	void TrailOn()
	{
		pinktr.time = 1f;
		bluetr.time = 1f;
		greentr.time = 1f;
		orangetr.time = 1f;
	}


	//Call this function every time you go past the screen constraints.
	void TrailWrap()
	{
		//Turn trails off by setting time to zero.
		pinktr.time = 0f;	 
		bluetr.time = 0f;
		greentr.time = 0f;
		orangetr.time = 0f;

		//Turn trails on again
		Invoke ("TrailOn", 0.02f);	
	}

}
