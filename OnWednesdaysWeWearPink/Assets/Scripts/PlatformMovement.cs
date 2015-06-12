using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {

	public float Speed;
	public float LeftBorder;
	public float RightBorder;
	public MovingDirection _movingDirection;


	void Start () {
		_movingDirection = MovingDirection.Left;
		LeftBorder = LeftBorder == 0 ? -2 : LeftBorder;
		RightBorder = RightBorder == 0 ? 2 : RightBorder;
	}

	void Update () {
		if (_movingDirection == MovingDirection.Left && transform.position.x < LeftBorder) {
			_movingDirection = MovingDirection.Right;
		}

		if (_movingDirection == MovingDirection.Right && transform.position.x > RightBorder) {
			_movingDirection = MovingDirection.Left;
		}

		Move (_movingDirection);

	}

	private void Move(MovingDirection direction){

		if (direction == MovingDirection.Left) {
			transform.position = new Vector2 (transform.position.x - Speed/50, transform.position.y);
		} else if (direction == MovingDirection.Right) {
			transform.position = new Vector2 (transform.position.x + Speed/50, transform.position.y);
		}			
	}
}

public enum MovingDirection {Left, Right};
