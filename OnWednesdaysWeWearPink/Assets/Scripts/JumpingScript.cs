using UnityEngine;
using System.Collections;

public class JumpingScript : MonoBehaviour {

	Rigidbody2D _rigidBody;
	bool _grounded;
	public Transform groundCheck;
	float _groundRadius = 0.2f;
	public LayerMask whatIsGround;

	void Start () {
		InputRecogniser.OnTouch += Jump;
		_rigidBody = this.GetComponent<Rigidbody2D> ();
	}

	void Update () {
	
	}

	void FixedUpdate() {

		_grounded = Physics2D.OverlapCircle (groundCheck.position, _groundRadius, whatIsGround);

		if (_grounded) {
			
		}
	
	}

	void Jump() {
		if (!_grounded) {
			_rigidBody.AddForce (new Vector2(0, 20), ForceMode2D.Impulse);
		}

	}

}
