using UnityEngine;
using System.Collections;

public class ProjectilePet : MonoBehaviour 
{
	Pet currPet;
	float speed;

	void setCurrPet(Pet pet)
	{
		currPet = pet;
	}

	void launch()
	{
		gameObject.rigidbody2D.AddForce(new Vector2(12, 6));
	}

	// Use this for initialization
	void Start () {
		if (currPet.getType() == PetType.fire)
		{
			gameObject.tag = "fire";
		}

		if (currPet.getType() == PetType.water)
		{
			gameObject.tag = "water";
		}

		if (currPet.getType() == PetType.generic)
		{
			gameObject.tag = "generic";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
