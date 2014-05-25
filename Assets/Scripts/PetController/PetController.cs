using UnityEngine;
using System.Collections;

public class PetController : MonoBehaviour
{
	const float MAX_DISTANCE_FROM_PLAYER = 2.5f;
	const float CATCH_UP_DISTANCE = 5.0f;

	public float speed;	
	public float jumpVal;

	private Quaternion movingRight;
	private Quaternion movingLeft;

	bool isJumping;
	public Pet currPet;
	float timer;
	int petID;

	public bool isFront = false;

	static int numPets = 0;

	public void addToTeam()
	{
		PlayerAttributes.chain.addToChain (currPet);
	}

	public bool  isGrounded ()
	{
		Debug.DrawRay ( new Vector2(transform.position.x, transform.position.y - 1.49f), -Vector2.up * 0.25f, Color.blue, 0.05f);
		
		RaycastHit2D hit = Physics2D.Raycast (new Vector2(transform.position.x, transform.position.y - 1.49f), -Vector2.up, 0.25f);
		
		if(hit.collider != null)
		{
			if (hit.collider.gameObject.tag == "ground") 
			{
				return true;
			}
		}
		
		//Debug.Log (grounded);
		return false;
	}

	// Use this for initialization
	void Start ()
	{
		if (gameObject.tag == "fire")
		{
			currPet = new Pet(numPets, PetType.fire);
		}

		else if (gameObject.tag == "water")
		{
			currPet = new Pet(numPets, PetType.water);
		}

		else
		{
			currPet = new Pet(numPets, PetType.generic);
		}

		petID = numPets;
		print ("curr num pets: " + numPets);
		numPets++;
		jumpVal = 20;
		gameObject.layer = LayerStack.assign();
		currPet.setInstanceID(gameObject.GetInstanceID());
		PlayerAttributes.chain.addToChain(currPet);
	}

	// Update is called once per frame
	void Update ()
	{
		Vector3 dist;
		dist = PlayerAttributes.chain.nextInLineDist(currPet);
		timer += Time.deltaTime;

		if (currPet.isDiscarded() && currPet.getType() != PetType.generic)
		{
			Destroy(gameObject);
		}
		else if (currPet.isDiscarded() && currPet.getType() == PetType.generic)
		{
			PlayerAttributes.chain.addToChain(currPet);
			currPet.setDiscarded(false);
		}

		if (dist.x < 0)
		{
			currPet.setDirection(Direction.right);
			//print(currPet.getDirection());
		}
		else
		{
			currPet.setDirection(Direction.left);
			//print(currPet.getDirection());
		}

		if (dist.x > MAX_DISTANCE_FROM_PLAYER) 
		{	
			if (dist.x > CATCH_UP_DISTANCE)
			{
				movingLeft = gameObject.transform.localRotation;
				movingLeft.y = 180.0f;
				gameObject.transform.rotation = movingLeft;
				gameObject.GetComponent<Animator>().enabled = true;

				gameObject.transform.Translate(new Vector3(0.13f + speed, 0.0f));

				if (dist.y < 0 && isJumping == false)
				{
					gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 0.5f + jumpVal));
					isJumping = true;
				}
			}
			else
			{
				movingLeft = gameObject.transform.localRotation;
				movingLeft.y = 180.0f;
				gameObject.transform.rotation = movingLeft;
				gameObject.GetComponent<Animator>().enabled = true;

				gameObject.transform.Translate(new Vector3(0.1f + speed, 0.0f));
			}
		}

		if (dist.x < -MAX_DISTANCE_FROM_PLAYER)
		{
			if (dist.x < -CATCH_UP_DISTANCE)
			{
				movingRight = gameObject.transform.localRotation;
				movingRight.y = 0.0f;
				gameObject.transform.rotation = movingRight;
				gameObject.GetComponent<Animator>().enabled = true;

				gameObject.transform.Translate(new Vector3(0.13f + speed, 0.0f));

				if (dist.y < 0 && isJumping == false)
				{
					gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 0.5f + jumpVal));
					isJumping = true;
				}
			}

			else
			{
				movingRight = gameObject.transform.localRotation;
				movingRight.y = 0.0f;
				gameObject.transform.rotation = movingRight;
				gameObject.GetComponent<Animator>().enabled = true;

				gameObject.transform.Translate(new Vector3(0.1f + speed, 0.0f));
			}
		}

		if(isGrounded())
		{
			isJumping = false;
		}
		
		/*if (Input.GetKeyDown(KeyCode.O))
		{
			PlayerAttributes.chain.addToChain(currPet);
		}*/

		currPet.setPosition(gameObject.transform.position);
	}
}

