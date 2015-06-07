using UnityEngine;
using System.Collections;

public class InputRecogniser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckInput ();
	}

	void CheckInput () {
		
		if (Input.GetMouseButtonDown (0)) {
			Debug.Log ("jump!");
		}
	}
}
