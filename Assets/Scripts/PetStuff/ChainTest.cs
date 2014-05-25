using UnityEngine;
using System.Collections;

public class ChainTest : MonoBehaviour 
{
	PetChain test = new PetChain();

	// Use this for initialization
	void Start () 
	{
		int j = 6;
		for (int i = 0; i < 6; i++)
		{
			test.addToChain (new Pet(j));
			j--;
		}

		test.printChain ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		test.findPet (2);
	}
}
