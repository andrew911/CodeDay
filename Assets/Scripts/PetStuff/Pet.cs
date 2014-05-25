using UnityEngine;
using System.Collections;

public enum PetType {generic, fire, waterOrIce, earth};

public class Pet //: MonoBehaviour 
{
	PetType type;
	int petNum;
	Vector3 position;

	/*
	 * start constructors
	 */

	public Pet()
	{
	}

	public Pet(int num)
	{
		petNum = num;
	}

	public Pet(int num, PetType x)
	{
		petNum = num;
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

	public int getPetNum()
	{
		return petNum;
	}

	public Vector3 getPosition()
	{
		return position;
	}

	/*
	 * End getter methods
	 */


	/*
	 * Start setter methods
	 */

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
