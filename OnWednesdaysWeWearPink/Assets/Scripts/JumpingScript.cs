using UnityEngine;
using System.Collections;

public class JumpingScript : MonoBehaviour {

	void Start () {
		InputRecogniser.OnTouch += Jump;
	}

	void Update () {
	
	}

	void Jump() {
		Debug.Log ("jump!");
	}

}
