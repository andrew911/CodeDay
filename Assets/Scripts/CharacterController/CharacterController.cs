using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour
{

		//These values are public to be edited from the inspector for easy use
		public float speed;	
		public float jumpVal;
		public float dblVal;
	
		//Internal variables
		private bool doubleJump;
		private bool isJumping;
		private bool grounded = true;
		private bool isIdle;
		private Ray ray;	//Raycast used for checking if grounded

		private float timer;


		public GameObject throwIt;
		
		//private float distance = -1;

		//Made to force animation to look like it's moving left or right
		private Quaternion movingRight;
		private Quaternion movingLeft;

		// Use this for initialization
		void Start ()
		{
			isJumping = false;
			doubleJump = false;
			movingRight.y = 0.0f;
			movingLeft.y = 180.0f;
			isGrounded ();
			gameObject.layer = 14;
		}
	
		// Update is called once per frame
		void Update ()
		{

			timer += Time.deltaTime;
			isGrounded ();

			//This is the input code for character movement
			if (Input.GetKey (KeyCode.D))
			{
				gameObject.transform.Translate(new Vector3(0.1f + speed, 0.0f));
				PlayerAttributes.setDirection (Direction.right);
				PlayerAttributes.setMoving (true);
				movingRight = gameObject.transform.localRotation;
				movingRight.y = 0.0f;
				gameObject.transform.rotation = movingRight;
				gameObject.GetComponent<Animator>().enabled = true;
				timer = 0;
			}
			if (Input.GetKey (KeyCode.A)) 
			{

				movingLeft = gameObject.transform.localRotation;
				movingLeft.y = 180.0f;
				gameObject.transform.rotation = movingLeft;

				gameObject.transform.Translate(new Vector3(0.1f - speed, 0.0f));
				PlayerAttributes.setDirection(Direction.left);
				PlayerAttributes.setMoving (true);
				gameObject.GetComponent<Animator>().enabled = true;
				timer = 0;
				
			}
			if (Input.GetKeyDown (KeyCode.Space) && !isJumping && grounded) 
			{
				//gameObject.rigidbody2D.AddForce
				gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 0.5f + jumpVal));
			}
			if (Input.GetKeyDown (KeyCode.Space) && !grounded && !doubleJump) 
			{
				gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 0.5f + dblVal));
				doubleJump = true;
       		}

			if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.D))
			{
				PlayerAttributes.setMoving (false);
			}

			if (Input.GetKeyDown (KeyCode.Q))
			{
				PlayerAttributes.chain.downSelection();
				PlayerAttributes.chain.switchToFront();
			}

			if (Input.GetKeyDown(KeyCode.E))
			{
				PlayerAttributes.chain.upSelection();
				PlayerAttributes.chain.switchToFront();
			}

			if (Input.GetKeyDown(KeyCode.F))
			{
				Pet temp;
				temp = PlayerAttributes.chain.removeFromChain();

				throwIt.rigidbody2D.AddForce(new Vector2(500, 500));
				temp.setDiscarded (true);
			}

			if (timer >= 0.3f)
			{
				isIdle = true;
				gameObject.GetComponent<Animator>().enabled = false;
			}

			PlayerAttributes.setPosition(gameObject.transform.position);
		}
		
		public bool isGrounded ()
		{
		Debug.DrawRay ( new Vector2(transform.position.x, transform.position.y - 1.49f), -Vector2.up * 0.25f, Color.blue, 0.05f);

		RaycastHit2D hit = Physics2D.Raycast (new Vector2(transform.position.x, transform.position.y - 1.49f), -Vector2.up, 0.25f);

		if(hit.collider != null)
		{
			if (hit.collider.gameObject.tag == "ground") 
			{
				grounded = true;
				doubleJump = false;
			}
		}else{
			grounded = false;
        }
        
        //Debug.Log (grounded);
		return grounded;
		}
}
