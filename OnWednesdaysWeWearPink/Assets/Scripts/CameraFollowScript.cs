using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public Transform character;
	public float CameraOffset, CameraMovementSpeed;

	void Start () {
	}
	

	void Update () {
		var from = transform.position;
		var to = new Vector3 (transform.position.x, character.position.y + CameraOffset, transform.position.z);
		transform.position = Vector3.Lerp(from, to, CameraMovementSpeed);
	}
}
