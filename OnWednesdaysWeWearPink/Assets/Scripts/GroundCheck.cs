using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {



	void Start () {
	
	}
		
	void Update () {
	
	}

	void FixedUpdate() {
		var jumpingScript = (JumpingScript) transform.parent.GetComponentInChildren<JumpingScript> () as JumpingScript;

		if (jumpingScript.IsGrounded) {
			PlatformMovement platformMovement = jumpingScript.Ground.GetComponent<PlatformMovement> ();
		} else {
			//Debug.Log ("Pikachu is in the air!");
		}

	}

	private void Move(MovingDirection direction, float speed){
		if (direction == MovingDirection.Left) {
			transform.position = new Vector2 (transform.position.x - speed/50, transform.position.y);
		} else if (direction == MovingDirection.Right) {
			transform.position = new Vector2 (transform.position.x + speed/50, transform.position.y);
		}			
	}
}
