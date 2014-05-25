using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//GAME MANAGER SCRIPT

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (PlayerAttributes.getHealth ());
	}
}
