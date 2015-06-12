using UnityEngine;
using System.Collections;

public class JumpingScript : MonoBehaviour {

	Rigidbody2D _rigidBody;
	bool _grounded;
	public Transform groundCheck;
	float _groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float JumpingForce;

	float _chargeLevel = 0;
	float _chargeSpeed = 2f;
	float _jumpVelocity = 50f;

	void Start () {
		InputRecogniser.OnTouchDown += Charge;
		InputRecogniser.OnTouchRelease += Jump;
		_rigidBody = this.GetComponent<Rigidbody2D> ();
	}

	void Update () {
	
	}

	void FixedUpdate() {

		_grounded = Physics2D.OverlapCircle (groundCheck.position, _groundRadius, whatIsGround);

	}

	void Jump() {
		Debug.Log ("Jump " + _chargeLevel);
		_rigidBody.AddForce (new Vector2(0, _jumpVelocity) * _chargeLevel, ForceMode2D.Impulse);
		_chargeLevel = 0;
	}

	void Charge() {
		
		if (_grounded && _chargeLevel < 2) {
			Debug.Log ("charge");
			_chargeLevel += Time.deltaTime * _chargeSpeed;
		}
	}

}
