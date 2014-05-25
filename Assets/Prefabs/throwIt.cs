using UnityEngine;
using System.Collections;

public class throwIt : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


		if(Input.GetKeyDown(KeyCode.F)){
			if(gameObject.GetInstanceID() == PlayerAttributes.chain.elementAt(PlayerAttributes.chain.getFrontVal()).getInstanceID())
			{
				gameObject.GetComponent<PetController>().enabled = false;
				gameObject.rigidbody2D.AddForce( new Vector2(100, 20));
			}

			Pet temp;
			temp = PlayerAttributes.chain.removeFromChain();
			
			//throwIt.rigidbody2D.AddForce(500, 500);
			temp.setDiscarded (true);

		}
	
	}
}
