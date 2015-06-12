using UnityEngine;
using System.Collections;

public class JumpingScript : MonoBehaviour {

	Rigidbody2D _rigidBody;

	void Start () {
		InputRecogniser.OnTouch += Jump;
		_rigidBody = this.GetComponent<Rigidbody2D> ();
	}

	void Update () {
	
	}

	void Jump() {
		_rigidBody.AddForce (new Vector2(0, 20), ForceMode2D.Impulse);
	}

}
