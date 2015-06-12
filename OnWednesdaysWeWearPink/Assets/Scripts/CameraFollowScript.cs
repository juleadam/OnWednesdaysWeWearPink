using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour {

	public Transform character;

	void Start () {
	}
	

	void Update () {

		if ((character.position.y - transform.position.y) > 10f) {
			var from = transform.position;
			var to = new Vector3 (transform.position.x, transform.position.y + 50f, transform.position.z);
			transform.position = Vector3.Lerp(from, to, 2f);
		}
	}
}
