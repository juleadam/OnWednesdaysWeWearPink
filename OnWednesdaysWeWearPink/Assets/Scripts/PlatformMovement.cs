using UnityEngine;

public enum MovingDirection {Left, Right, None};

public class PlatformMovement : MonoBehaviour {

	public float Speed;
	public float LeftBorder;
	public float RightBorder;
	public MovingDirection MovingDirection;


	void Start () {
		MovingDirection = MovingDirection.Left;
		LeftBorder = LeftBorder <= 0 ? -2 : LeftBorder;
		RightBorder = RightBorder <= 0 ? 2 : RightBorder;
	}

	void Update () {
		if (MovingDirection == MovingDirection.Left && transform.position.x < LeftBorder) {
			MovingDirection = MovingDirection.Right;
		}

		if (MovingDirection == MovingDirection.Right && transform.position.x > RightBorder) {
			MovingDirection = MovingDirection.Left;
		}

		Move (MovingDirection);

	}

	private void Move(MovingDirection direction){
		if (direction == MovingDirection.Left) {
			transform.position = new Vector2 (transform.position.x - Speed/50, transform.position.y);
		} else if (direction == MovingDirection.Right) {
			transform.position = new Vector2 (transform.position.x + Speed/50, transform.position.y);
		}			
	}
}
