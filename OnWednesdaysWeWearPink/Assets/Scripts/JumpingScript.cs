using UnityEngine;

public class JumpingScript : MonoBehaviour {

	public Collider2D Ground;
	public bool IsGrounded;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public float HorizontalSpeed;
	public MovingDirection MovingDirection;

	Rigidbody2D _rigidBody;
	const float _groundRadius = 0.2f;
	const float _minChargeLevel = 4f;
	float _chargeLevel = _minChargeLevel;
	float _maxChargeLevel = 10f;
	float _chargeSpeed = 10f;
	float _jumpVelocity = 5f;

	public delegate void ChargerEventHandler(float chargeAmount);
	public static event ChargerEventHandler OnCharge;
	public static event ChargerEventHandler OnJump;

	void Start () {
		InputRecogniser.OnTouchDown += Charge;
		InputRecogniser.OnTouchRelease += Jump;
		_rigidBody = GetComponent<Rigidbody2D> ();
		IsGrounded = false;
		MovingDirection = MovingDirection.None;
	}

	void FixedUpdate() {
		IsGrounded = Physics2D.OverlapCircle (groundCheck.position, _groundRadius, whatIsGround);
		Ground = Physics2D.OverlapCircle (groundCheck.position, _groundRadius, whatIsGround);

		if (IsStandingOnSolidGround ()) {
			HorizontalSpeed = 0;
			MovingDirection = MovingDirection.None;
		} else if (IsStandingOnMovingPlatform ()) {
			HorizontalSpeed = Ground.GetComponent<PlatformMovement> ().Speed;
			MovingDirection = Ground.GetComponent<PlatformMovement> ().MovingDirection;
		} else {
			Move (MovingDirection, HorizontalSpeed);
		}


	}

	void Jump() {
		if (IsGrounded) {
			var jumpForce = _jumpVelocity * _chargeLevel;

			if (OnJump != null) {
				OnJump (0);
			}

			_rigidBody.AddForce (new Vector2(0, jumpForce), ForceMode2D.Impulse);
			_chargeLevel = _minChargeLevel;
		}
	}

	void Charge() {
		if (IsGrounded) {
			if (_chargeLevel < _maxChargeLevel) {
				_chargeLevel += Time.deltaTime * _chargeSpeed;
			} else {
				_chargeLevel = _maxChargeLevel;
			}

			if (OnCharge != null) {
				OnCharge ((_chargeLevel - _minChargeLevel) / (_maxChargeLevel - _minChargeLevel));
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

	public bool IsStandingOnMovingPlatform(){
		return IsGrounded && Ground.GetComponent<PlatformMovement> ();
	}

	public bool IsStandingOnSolidGround(){
		return IsGrounded && !Ground.GetComponent<PlatformMovement> ();
	}

	private void Move(MovingDirection direction, float speed){
		if (direction == MovingDirection.Left) {
			transform.position = new Vector2 (transform.position.x - speed/50, transform.position.y);
		} else if (direction == MovingDirection.Right) {
			transform.position = new Vector2 (transform.position.x + speed/50, transform.position.y);
		}			
	}

}
