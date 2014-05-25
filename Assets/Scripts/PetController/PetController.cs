using UnityEngine;
using System.Collections;

public class PetController : MonoBehaviour
{
	const float MAX_DISTANCE_FROM_PLAYER = 5;

	public float speed;	
	public float jumpVal;

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
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Mathf.Abs(PlayerAttributes.chain.nextInLineDist(currPet).x) > MAX_DISTANCE_FROM_PLAYER) 
		{	
			if (PlayerAttributes.getDirection() == Direction.right)
			{
				gameObject.transform.Translate(new Vector3(0.1f + speed, 0.0f));
			}
			else
			{
				gameObject.transform.Translate(new Vector3(-0.1f - speed, 0.0f));
			}
		}

		if (Input.GetKeyDown(KeyCode.O))
		{
			PlayerAttributes.chain.addToChain(currPet);
		}

		currPet.setPosition(gameObject.transform.position);
	}
}

