using UnityEngine;
using System.Collections;

public class PlatformLifeTime : MonoBehaviour {
	public bool Cull = false;

	public float FallingVelocity;
	public int TimeToLive;

	private float StartingHeight;
	private bool Falling = false;
	private bool CharacterHasGoneAbove = false;
	private long TimeOfCharacterAbovePlatformMs;

	private GameObject Character;

	void Start () {
		StartingHeight = this.transform.position.y;
		Character = GameObject.Find ("Character");
	}

	void Update () {
		if (!Cull && this.transform.position.y < StartingHeight - 100f) {
			Cull = true;
		}

		if (!CharacterHasGoneAbove) {
			CharacterHasGoneAbove = StartingHeight < Character.transform.position.y - 2f;
			if(CharacterHasGoneAbove) {
				TimeOfCharacterAbovePlatformMs = (long)Time.time * 1000;
				Debug.Log(TimeOfCharacterAbovePlatformMs);
			}
		} else {
			if(((long)Time.time*1000) - TimeOfCharacterAbovePlatformMs > TimeToLive) {
				Falling = true;
			}
		}

		if (Falling) {
			this.transform.position = new Vector2(this.transform.position.x, this.transform.position.y-(FallingVelocity*Time.deltaTime));
		}
	}
}
