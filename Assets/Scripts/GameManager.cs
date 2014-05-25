using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//GAME MANAGER SCRIPT

	// Use this for initialization
	void Start () {
		PlayerAttributes.setHealth (3);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (PlayerAttributes.getHealth ());


		if (PlayerAttributes.getHealth () <= 0) {
			Debug.Log ("YOU LOSE");
				}
	}
}
