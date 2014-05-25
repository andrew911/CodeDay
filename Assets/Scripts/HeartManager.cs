using UnityEngine;
using System.Collections;

public class HeartManager : MonoBehaviour {

	public Texture aTexture;
	public Texture dead;


	private int tempInt;

	// Use this for initialization
	void Start () {
		PlayerAttributes.setHealth (3);
	}
	
	// Update is called once per frame
	void Update () {
		tempInt = PlayerAttributes.getHealth ();
	}


	void OnGUI()
	{

		Debug.Log (tempInt);

		if (tempInt >= 3) {
						GUI.DrawTexture (new Rect (100, 50, 80, 80), aTexture);		
						GUI.DrawTexture (new Rect (200, 50, 80, 80), aTexture);	
						GUI.DrawTexture (new Rect (300, 50, 80, 80), aTexture);	
						//	 ScaleMode.StretchToFill, true, 10.0F);
				} else if (tempInt == 2) {
						GUI.DrawTexture (new Rect (100, 50, 80, 80), aTexture);		
						GUI.DrawTexture (new Rect (200, 50, 80, 80), aTexture);	
						GUI.DrawTexture (new Rect (300, 50, 80, 80), dead);	
				} else if (tempInt == 1) {
						GUI.DrawTexture (new Rect (100, 50, 80, 80), aTexture);		
						GUI.DrawTexture (new Rect (200, 50, 80, 80), dead);	
						GUI.DrawTexture (new Rect (300, 50, 80, 80), dead);	
				} else if (tempInt <= 0) {
						GUI.DrawTexture (new Rect (100, 50, 80, 80), dead);		
						GUI.DrawTexture (new Rect (200, 50, 80, 80), dead);	
						GUI.DrawTexture (new Rect (300, 50, 80, 80), dead);
				}
	}
}
