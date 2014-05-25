using UnityEngine;
using System.Collections;

public static class LayerStack //: MonoBehaviour 
{
	const int LAYER_OFFSET = 8;
	const int MAX_LAYER = 6;

	static int top = 0;

	public static int assign()
	{
		if (top < MAX_LAYER)
		{
			int temp = top;
			top++;
			return temp + LAYER_OFFSET;
		}

		Debug.Log("No layers left to assign");
		return -1;
	}

	public static void revoke()
	{
		if (top == 0)
		{
			Debug.Log("No layers assigned");
		}

		else
		{
			top--;
		}
	}

	/*// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}*/
}
