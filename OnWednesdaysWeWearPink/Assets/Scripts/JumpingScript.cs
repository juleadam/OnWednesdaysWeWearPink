using UnityEngine;

public class JumpingScript : MonoBehaviour {

	public Collider2D Ground;
	public bool IsGrounded;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float MaxJumpForce;

	Rigidbody2D _rigidBody;
	const float _groundRadius = 0.2f;
	float _chargeLevel = 0;
	const float _maxChargeLevel = 3f;
	const float _chargeSpeed = 5f;
	const float _jumpVelocity = 25f;

	public delegate void ChargerEventHandler(float chargeAmount);
	public static event ChargerEventHandler OnCharge;
	public static event ChargerEventHandler OnJump;

	void Start () {
		InputRecogniser.OnTouchDown += Charge;
		InputRecogniser.OnTouchRelease += Jump;
		_rigidBody = GetComponent<Rigidbody2D> ();
		IsGrounded = false;
	}

	void FixedUpdate() {
		IsGrounded = Physics2D.OverlapCircle (groundCheck.position, _groundRadius, whatIsGround);
		Ground = Physics2D.OverlapCircle (groundCheck.position, _groundRadius, whatIsGround);
	}

	void Jump() {
		
		var jumpForce = _jumpVelocity * _chargeLevel;

		if (OnJump != null) {
			OnJump (0);
		}

		_rigidBody.AddForce (new Vector2(0, jumpForce), ForceMode2D.Impulse);
		_chargeLevel = 0;
	}

	void Charge() {
		if (IsGrounded) {
			if (_chargeLevel < _maxChargeLevel) {
				_chargeLevel += Time.deltaTime * _chargeSpeed;
			} else {
				_chargeLevel = _maxChargeLevel;
			}

			if (OnCharge != null) {
				OnCharge (_chargeLevel / _maxChargeLevel);
			}
		}
	}

	void OnDestroy() {
		UnsubscribeEvents ();
	}

	void UnsubscribeEvents() {
		InputRecogniser.OnTouchDown -= Charge;
		InputRecogniser.OnTouchRelease -= Jump;
	}

}
