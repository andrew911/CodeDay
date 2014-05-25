using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	//This script will manage enemy behavior


	private bool grounded = true;
	private bool isWalking = false;

	private bool isBurning;

	public float burnTimer;

	private float timer;
	private float waitTime = 2.5f;

	private int spot = 1; //if spot is at 1 go to point B if spot is at 2 go to point A

	public GameObject pointA;
	public GameObject pointB;

	public GameObject fireDrop;

	//Stores true coord's 
	private Vector2 trueB;
	private Vector2 trueA;

	public float speed;

	public GameObject LOGOB;

	Vector2 objPoint;

	//Made to force animation to look like it's moving left or right
	private Quaternion movingRight;
	private Quaternion movingLeft;

	// Use this for initialization
	void Start () 
	{
		objPoint = trueA;//Objective point ='s the desired location
		trueB = pointB.transform.position;
		trueA = pointA.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{

		//BURN CODE IS SLOPPY
		if (gameObject.name == "Logs_Fire_Anim_0") 
		{
			burnTimer += Time.deltaTime;
		}
		if (gameObject.tag == "poop") {
			Debug.Log ("SOIFHLSKDHLSKDHGLSIURFHLWIEUTHLWIEUHLSDHG");
				}

		if (burnTimer >= 2.0f)
		{
			Instantiate(LOGOB, GameObject.Find ("Logs_Fire_Anim_0").transform.position, Quaternion.identity);
			GameObject.Destroy(GameObject.Find ("Logs_Fire_Anim_0"));


		}


		//Debug.Log (trueA.x);
		//Handles enemy paths
		if (!isWalking) 
		{
			timer += Time.deltaTime;
		}
		if (timer >= waitTime) 
		{
			isWalking = true;
			timer = 0.0f;

		}
		if (isWalking) 
		{
			moveEnemy();
		}
	}

	void moveEnemy()
	{


		//*******************************************
		//****THE LOGIC IS SKEWED. TRUST NOTHING*****
		//*******************************************

		if (spot == 1) 
		{
			gameObject.GetComponent<Animator>().enabled = true;
			movingRight = gameObject.transform.localRotation;
			movingRight.y = 180.0f;
			gameObject.transform.rotation = movingRight;

			this.gameObject.transform.Translate(new Vector3(-0.1f + speed, 0.0f));

			if(this.gameObject.transform.position.x >= trueB.x){
				gameObject.GetComponent<Animator>().enabled = false;
				isWalking = false;
				spot = 2;
				objPoint.x = trueA.x;

				movingLeft = gameObject.transform.localRotation;
				movingLeft.y = 180.0f;
				gameObject.transform.rotation = movingLeft;
			}
		}
		if (spot == 2) 
		{
			gameObject.GetComponent<Animator>().enabled = true;
			movingLeft = gameObject.transform.localRotation;
			movingLeft.y = 0.0f;
			gameObject.transform.rotation = movingLeft;

			this.gameObject.transform.Translate(new Vector3(-0.1f - speed, 0.0f));

			if(this.gameObject.transform.position.x <= trueA.x){
				gameObject.GetComponent<Animator>().enabled = false;
				isWalking = false;
				spot = 1;
				objPoint.x = trueB.x;

				movingRight = gameObject.transform.localRotation;
				movingRight.y = 0.0f;
				gameObject.transform.rotation = movingRight;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){

		if (collision.gameObject.tag != "ground") 
		{
			isWalking = false;
			if(spot == 1)
			{
				spot = 2;
			}else
			{
				spot = 1;
			}
		}

		if (collision.gameObject.tag == "Player") 
		{
			PlayerAttributes.setHealth((PlayerAttributes.getHealth()) - 1);
		}


		//if attacked by projectile
		if (collision.gameObject.tag == "fire" ) 
		{
			isBurning = true;
			//Play animation of death
			if(gameObject.name == "logs"){
				Debug.Log ("BURNING");
				Instantiate(LOGOB, GameObject.Find ("logs").transform.position, Quaternion.identity);
				isBurning = true;
				GameObject.Destroy(GameObject.Find("logs"));
				GameObject.Find ("Logs_Fire_Anim_0").GetComponent<Animator>().enabled = true;

			}

			   GameObject.Destroy(gameObject);
		}

		if (collision.gameObject.tag == "generic" && gameObject.name == "fireBad") 
		{
			Instantiate(fireDrop, gameObject.transform.position, Quaternion.identity);
			//PlayerAttributes.chain.addToChain(fireDrop.GetComponent<PetController>().currPet);
			//Instantiate(LOGOB, GameObject.Find ("Logs_Fire_Anim_0").transform.position, Quaternion.identity);
			GameObject.Destroy(gameObject);
		}
	}

	public bool  isGrounded ()
	{
		//Debug.DrawRay ( new Vector2(transform.position.x, transform.position.y - 0.9f), -Vector2.up * 0.25f, Color.blue, 0.05f);
		
		RaycastHit2D hit = Physics2D.Raycast (new Vector2(transform.position.x, transform.position.y - 0.9f), -Vector2.up, 0.25f);
		
		if(hit.collider != null)
		{
			if (hit.collider.gameObject.tag == "ground") 
			{
				grounded = true;
			}
		}else
		{
			grounded = false;
		}
		return grounded;
	}
}
