using UnityEngine;
using System.Collections;

public class DESTROY : MonoBehaviour {

	public float temp;

	public GameObject LOGOB;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		temp = gameObject.GetComponent<EnemyBehavior> ().burnTimer;

		if (temp >= 2.0f) {
		//	Instantiate(LOGOB, GameObject.Find ("Logs_Fire_Anim_0").transform.position, Quaternion.identity);
			GameObject.Destroy(gameObject);
				}
	}
}
