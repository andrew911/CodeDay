using UnityEngine;
using System.Collections;

public class ChainTest : MonoBehaviour 
{
	PetChain test = new PetChain();

	// Use this for initialization
	void Start () 
	{
		for (int i = 0; i < 6; i++)
		{
			test.addToChain (new Pet(i));
			print("front is " + test.getFrontVal ());
		}

		for (int i = 0; i < 6; i++)
		{
			print ("index " + i + ", pet " + test.elementAt(i).getPetNum() + " front is " + test.getFrontVal());
		}

		//going to try to add another pet, should fail
		test.addToChain (new Pet(7));
		for (int i = 0; i < 120; i++)
		{
			test.addToChain (new Pet());
		}

		for (int i = 0; i < 6; i++)
		{
			print ("index " + i + ", pet " + test.elementAt(i).getPetNum() + " front is " + test.getFrontVal());
		}

		print("Pet " + test.removeFromChain().getPetNum() + " removed, front is now " + test.getFrontVal());

		for (int i = 0; i < 120; i++)
		{
			test.removeFromChain ();
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
