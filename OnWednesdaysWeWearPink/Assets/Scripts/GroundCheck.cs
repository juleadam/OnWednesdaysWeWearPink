using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {
		
	void Update () {
		var jumpingScript = (JumpingScript) transform.parent.GetComponentInChildren<JumpingScript> () as JumpingScript;

		if (jumpingScript.IsGrounded) {
			PlatformMovement platformMovement = jumpingScript.Ground.GetComponent<PlatformMovement> ();

			if (platformMovement != null) {
				Move (platformMovement.MovingDirection, platformMovement.Speed);
			}

		} 
	}

	private void Move(MovingDirection direction, float speed){
		if (direction == MovingDirection.Left) {
			transform.parent.transform.position = new Vector2 (transform.parent.transform.position.x - speed/50, transform.parent.transform.position.y);
		} else if (direction == MovingDirection.Right) {
			transform.parent.transform.position = new Vector2 (transform.parent.transform.position.x + speed/50, transform.parent.transform.position.y);
		}			
	}
}
