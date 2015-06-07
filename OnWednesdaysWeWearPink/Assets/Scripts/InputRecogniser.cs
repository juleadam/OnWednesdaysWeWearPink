using UnityEngine;
using System.Collections;

public class InputRecogniser : MonoBehaviour {

	public delegate void InputEventHandler();
	public static event InputEventHandler OnTouch;
	
	void Update () {
		CheckInput ();
	}

	void CheckInput () {
		
		if (Input.GetMouseButtonDown (0)) {
			if (OnTouch != null) {
				OnTouch ();
			}
		}
	}
}
