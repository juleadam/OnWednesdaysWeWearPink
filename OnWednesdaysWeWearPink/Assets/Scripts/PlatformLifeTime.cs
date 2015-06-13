using UnityEngine;
using System.Collections;

public class PlatformLifeTime : MonoBehaviour {
	public bool Cull = false;

	public float TimeToLive;
	private bool WeHaveTouchDown = false;
	private bool WeHaveLostTouchDown = false;
	private float TimeOfCharacterAbovePlatform = 0;

	private GameObject Character;
	private JumpingScript CharacterJumpingScript;

	void Start () {
		Character = GameObject.Find ("Character");
		CharacterJumpingScript = (JumpingScript) Character.GetComponentInChildren<JumpingScript> () as JumpingScript;
	}

	void Update () {
		if (CharacterJumpingScript.IsGrounded && 
		    CharacterJumpingScript.Ground.GetInstanceID() == 
		    	this.GetComponent<BoxCollider2D>().GetInstanceID()) {
			WeHaveTouchDown = true;
		}

		if (WeHaveTouchDown && !CharacterJumpingScript.IsGrounded) {
			WeHaveLostTouchDown = true;
			GetComponent<Rigidbody2D>().isKinematic = false;
		}

		if (WeHaveLostTouchDown) {
			TimeOfCharacterAbovePlatform += Time.deltaTime;
		}

		if (TimeOfCharacterAbovePlatform > TimeToLive) {
			Cull = true;
		}
	}
}
