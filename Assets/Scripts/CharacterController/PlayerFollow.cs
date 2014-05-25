using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour {

	Vector3 tempPos;

	public float cameraY;
	public float cameraX;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//First level CameraY = 2.9f


		//This keeps the camera locked on the player

		tempPos = GameObject.FindWithTag("Player").gameObject.transform.position;
		tempPos.z = -10.0f;
		tempPos.y = cameraY; 		//This puts the camera up a little bit so that you dont see under the earth
		tempPos.x = tempPos.x + cameraX;
		gameObject.camera.transform.position = tempPos;
	}
}
