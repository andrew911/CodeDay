using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PetChain //: MonoBehaviour 
{
	const int MAX_PETS = 6;

	List<Pet> chain = new List<Pet>();
	int front = 0;
	public int selectedPet;

	public bool addToChain(Pet pet)
	{
		if (front < MAX_PETS) 
		{
			chain.Add(pet);
			front++;
			Debug.Log ("Pet added!");
			return true;
		}

		Debug.Log("Maximum number of pets already added");
		return false;
	}

	public Pet removeFromChain()
	{
		Pet temp = new Pet();

		if (front > 0) 
		{
			temp = chain[front - 1];
			chain.RemoveAt(front - 1);
			front--;
			return temp;
		}

		Debug.Log("No pets to remove");
		return null;
	}

	public Pet removeSelection()
	{
		Pet temp = new Pet();

		temp = chain[selectedPet];
		chain.RemoveAt(selectedPet);
		return temp;
	}

	public Pet elementAt(int i)
	{
		return chain[i];
	}

	public int findPet(int petID)
	{
		for (int i = 0; i < front; i++)
		{
			if (chain[i].getPetID() == petID)
			{
				Debug.Log ("pet found at: " + i);
				return i;
			}
		}
		
		Debug.Log ("pet not found :(");
		return -1;
	}

	public int getFrontVal()
	{
		return front;
	}

	public void printChain()
	{
		for (int i = 0; i < front; i++)
		{
			Debug.Log ("Pet: " + chain[i].getPetID());
		}
	}

	public void upSelection()
	{
		selectedPet = (selectedPet + 1) % front;
	}

	public void downSelection()
	{
		if (selectedPet > 0)
		{
			selectedPet--;
		}

		else
		{
			selectedPet = front - 1;
		}
	}

	public Vector3 nextInLineDist(Pet curr)
	{
		int i;
		i = findPet(curr.getPetID());
		
		if (i == front - 1)
		{
			return curr.getPosition() - PlayerAttributes.getPosition();
		}
		
		return curr.getPosition() - PlayerAttributes.chain.elementAt(i + 1).getPosition();
	}

	/*
	// Use this for initialization
	void Start () 
	{
		front = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
