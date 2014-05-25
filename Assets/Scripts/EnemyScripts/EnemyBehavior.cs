using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	//This script will manage enemy behavior


	private bool grounded = true;
	private bool isWalking = false;

	private float timer;
	private float waitTime = 2.5f;

	private int spot = 2; //if spot is at 1 go to point B if spot is at 2 go to point A

	public GameObject pointA;
	public GameObject pointB;

	//Stores true coord's 
	private Vector2 trueB;
	private Vector2 trueA;

	public float speed;

	Vector2 objPoint;

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

		if (spot == 1) 
		{
			this.gameObject.transform.Translate(new Vector3(0.1f + speed, 0.0f));
			if(this.gameObject.transform.position.x >= objPoint.x){
				isWalking = false;
				spot = 2;
				objPoint.x = trueA.x;
			}
		}
		if (spot == 2) 
		{
			this.gameObject.transform.Translate(new Vector3(-0.1f + speed, 0.0f));
			if(this.gameObject.transform.position.x <= objPoint.x){
				isWalking = false;
				spot = 1;
				objPoint.x = trueB.x;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision){

		Debug.Log ("IN");
		if (collision.gameObject.tag != "ground" && collision.gameObject.tag != "pet") 
		{
			Debug.Log ("OUT");
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
	}

	public bool  isGrounded ()
	{
		Debug.DrawRay ( new Vector2(transform.position.x, transform.position.y - 0.9f), -Vector2.up * 0.25f, Color.blue, 0.05f);
		
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
