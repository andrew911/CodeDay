using UnityEngine;
using System.Collections;

public enum PetType {generic, fire, water};

public class Pet //: MonoBehaviour 
{
	PetType type;
	int petID;
	Vector3 position;
	Direction direction;
	bool discarded;
	int instanceID;

	/*
	 * start constructors
	 */

	public Pet()
	{
	}

	public Pet(int num)
	{
		petID = num;
	}

	public Pet(int num, PetType x)
	{
		petID = num;
		type = x;
	}

	/*
	 * end constructors
	 */


	/*
	 * Start getter methods
	 */

	public PetType getType()
	{
		return type;
	}

	public int getPetID()
	{
		return petID;
	}

	public Vector3 getPosition()
	{
		return position;
	}

	public Direction getDirection()
	{
		return direction;
	}

	public bool isDiscarded()
	{
		return discarded;
	}

	public int getInstanceID()
	{
		return instanceID;
	}

	/*
	 * End getter methods
	 */


	/*
	 * Start setter methods
	 */

	public void setInstanceID(int x)
	{
		instanceID = x;
	}

	public void setPosition(Vector3 x)
	{
		position = x;
	}

	public void setDirection(Direction x)
	{
		direction = x;
	}

	public void setDiscarded(bool t)
	{
		discarded = t;
	}

	/*
	 * End setter methods
	 */ 

	/*// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
