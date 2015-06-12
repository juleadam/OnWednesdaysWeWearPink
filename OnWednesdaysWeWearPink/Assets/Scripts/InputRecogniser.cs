using UnityEngine;
using System.Collections;

public class InputRecogniser : MonoBehaviour {

	public delegate void InputEventHandler();
	public static event InputEventHandler OnTouchDown;
	public static event InputEventHandler OnTouchRelease;
	
	void Update () {
		CheckInput ();
	}

	void CheckInput () {
		
		if (Input.GetMouseButton (0)) {
			if (OnTouchDown != null) {
				OnTouchDown ();
			}
		}
		else if (Input.GetMouseButtonUp (0)) {
			if (OnTouchRelease != null) {
				OnTouchRelease ();
			}
		}

	}
}
