using UnityEngine;
using System.Collections;

public class SoundHandler : MonoBehaviour {

	void Start () {
		JumpingScript.OnJump += PlayJumpingSound;
	}

	void Update () {
		
	}

	void PlayJumpingSound (float chargeLevel)
	{
		Debug.Log ("Jumpingsound!");
		GetComponent<AudioSource> ().Play ();
	}

	void OnDestroy() {
		UnsubscribeEvents ();
	}

	void UnsubscribeEvents() {
		JumpingScript.OnJump -= PlayJumpingSound;
	}

}
