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
		private Ray ray;	//Raycast used for checking if grounded
		
		//private float distance = -1;

		// Use this for initialization
		void Start ()
		{
			isJumping = false;
			doubleJump = false;
			isGrounded ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			isGrounded ();

			//This is the input code for character movement
			if (Input.GetKey (KeyCode.D))
			{
				gameObject.transform.Translate(new Vector3(0.1f + speed, 0.0f));
				PlayerAttributes.setDirection (Direction.right);
				PlayerAttributes.setMoving (true);
			}
			if (Input.GetKey (KeyCode.A)) 
			{
				gameObject.transform.Translate(new Vector3(-0.1f - speed, 0.0f));
				PlayerAttributes.setDirection(Direction.left);
				PlayerAttributes.setMoving (true);
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

			PlayerAttributes.setPosition(gameObject.transform.position);
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
				doubleJump = false;
			}
		}else{
			grounded = false;
        }
        
        //Debug.Log (grounded);
		return grounded;
		}
}
