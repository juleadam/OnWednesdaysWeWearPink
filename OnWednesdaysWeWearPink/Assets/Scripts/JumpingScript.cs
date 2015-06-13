using UnityEngine;
using System.Collections;

public class JumpingScript : MonoBehaviour {

	Rigidbody2D _rigidBody;
	public Collider2D Ground;
	public bool IsGrounded;
	public Transform groundCheck;
	float _groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float MaxJumpForce;


	float _chargeLevel = 0;
	float _chargeSpeed = 2f;
	float _jumpVelocity = 25f;

	void Start () {
		InputRecogniser.OnTouchDown += Charge;
		InputRecogniser.OnTouchRelease += Jump;
		Debug.Log (_rigidBody);
		Debug.Log (this);
		_rigidBody = this.GetComponent<Rigidbody2D> ();
		Debug.Log (_rigidBody);


		IsGrounded = false;
	}

	void Update () {
	
	}

	void FixedUpdate() {

		IsGrounded = Physics2D.OverlapCircle (groundCheck.position, _groundRadius, whatIsGround);
		Ground = Physics2D.OverlapCircle (groundCheck.position, _groundRadius, whatIsGround);

	}

	void Jump() {
		if (_rigidBody == null) {
			Debug.Log (_rigidBody);
			Debug.Log (this);
			_rigidBody = this.GetComponent<Rigidbody2D> ();
			Debug.Log (_rigidBody);
		}
		Debug.Log ("Jump chargelevel" + _chargeLevel);

		var jumpForce = _jumpVelocity * _chargeLevel;
		if (jumpForce > MaxJumpForce) {
			jumpForce = MaxJumpForce;
		}
		Debug.Log (_rigidBody);
		_rigidBody.AddForce (new Vector2(0, jumpForce), ForceMode2D.Impulse);
		_chargeLevel = 0;
	}

	void Charge() {
		
		if (IsGrounded) {
			//Debug.Log ("charge");
			_chargeLevel += Time.deltaTime * _chargeSpeed;
			//Debug.Log ("chargelevel: " + _chargeLevel);
		}
	}

}
