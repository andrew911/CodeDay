using UnityEngine;
using System.Collections;

public enum Direction {right, left};
public enum Speed {slow, fast};

public static class PlayerAttributes
{
	static Direction playerDirection;
	static Speed playerSpeed;
	static Vector3 position;
	static bool moving;
	static bool idling;
	static int health;
	public static PetChain chain = new PetChain();

	/*
	 * Start setter methods
	 */

	public static void setDirection(Direction x)
	{
		playerDirection = x;
	}

	public static void setSpeed(Speed x)
	{
		playerSpeed = x;
	}

	public static void setPosition(Vector3 x)
	{
		position = x;
	}

	public static void setMoving(bool x)
	{
		moving = x;
	}

	public static void setIdling(bool x)
	{
		idling = x;
	}
	public static void setHealth(int x)
	{
		health = x;
	}

	/*
	 * End setter methods
	 */



	/*
	 * Start getter methods
	 */ 

	public static Speed getSpeed()
	{
		return playerSpeed;
	}

	public static Direction getDirection()
	{
		return playerDirection;
	}

	public static bool isMoving()
	{
		return moving;
	}

	public static Vector3 getPosition()
	{
		return position;
	}

	public static bool isIdling()
	{
		return idling;
	}

	public static int getHealth()
	{
		return health;
	}

	/*
	 * End getter methods
	 */ 

	/*// Use this for initialization
	void Start ()
	{
		//TODO: initialize these values
	}

	/*
	// Update is called once per frame
	void Update ()
	{
	
	}*/
}

