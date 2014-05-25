using UnityEngine;
using System.Collections;

public class PetController : MonoBehaviour
{
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
		if (PlayerAttributes.getDirection () == Direction.right && PlayerAttributes.isMoving ()) 
		{
			gameObject.transform.Translate(new Vector3(0.1f + speed, 0.0f));
		}

		if (PlayerAttributes.getDirection () == Direction.left && PlayerAttributes.isMoving ()) 
		{
			gameObject.transform.Translate(new Vector3(-0.1f - speed, 0.0f));
		}

		if (Input.GetKeyDown(KeyCode.O))
		{
			PlayerAttributes.chain.addToChain (currPet);
		}

		if (Input.GetKeyDown (KeyCode.P))
		{
			PlayerAttributes.chain.printChain();
		}

		if (Input.GetKeyDown (KeyCode.L))
		{
			PlayerAttributes.chain.upSelection ();
			print (PlayerAttributes.chain.selectedPet);
		}

		if (Input.GetKeyDown (KeyCode.K))
		{
			PlayerAttributes.chain.downSelection ();
			print (PlayerAttributes.chain.selectedPet);
		}
	}
}

