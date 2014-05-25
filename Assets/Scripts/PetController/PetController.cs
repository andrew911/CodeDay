using UnityEngine;
using System.Collections;

public class PetController : MonoBehaviour
{
	const float MAX_DISTANCE_FROM_PLAYER = 5.0f;
	const float CATCH_UP_DISTANCE = 8.0f;

	public float speed;	
	public float jumpVal;

	bool isJumping;
	Pet currPet;

	static int numPets = 0;

	public void addToTeam()
	{
		PlayerAttributes.chain.addToChain (currPet);
	}

	// Use this for initialization
	void Start ()
	{
		currPet = new Pet(numPets);
		print ("curr num pets: " + numPets);
		numPets++;
		jumpVal = 450;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 dist;
		dist = PlayerAttributes.chain.nextInLineDist(currPet);

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
				gameObject.transform.Translate(new Vector3(-0.3f - speed, 0.0f));

				if (dist.y < 0 /*&& isJumping == false*/)
				{
					gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 0.5f + jumpVal));
					//isJumping = true;
				}
			}
			else
			{
				gameObject.transform.Translate(new Vector3(-0.1f - speed, 0.0f));
			}
		}

		if (dist.x < -MAX_DISTANCE_FROM_PLAYER)
		{
			if (dist.x < -CATCH_UP_DISTANCE)
			{
				gameObject.transform.Translate(new Vector3(0.3f + speed, 0.0f));

				if (dist.y < 0 /*&& isJumping == false*/)
				{
					gameObject.rigidbody2D.AddForce(new Vector2(0.0f, 0.5f + jumpVal));
					//isJumping = true;
				}
			}

			else
			{
				gameObject.transform.Translate(new Vector3(0.1f + speed, 0.0f));
			}
		}

		if (Input.GetKeyDown(KeyCode.O))
		{
			PlayerAttributes.chain.addToChain(currPet);
		}

		currPet.setPosition(gameObject.transform.position);
	}
}

