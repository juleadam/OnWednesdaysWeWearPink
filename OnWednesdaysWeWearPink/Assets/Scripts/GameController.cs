using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject Character;

	public float WhereToDieOffset = 10;
	private float WhereToDie;

	private float Score = 0f;

	void Start () {
		WhereToDie = Character.transform.position.y;
	}

	void OnGUI() {
		if (GUI.Button (new Rect (10, 10, 100, 30), "Reset Level")) {
			ResetGame();
		}
		GUI.TextArea (new Rect (10, 50, 50, 30), Score.ToString());
	}

	void Update () {
		if (Character.transform.position.y > Score) {
			Score = Mathf.Round(Character.transform.position.y*100f)/100f;
		}
		if (Character.transform.position.y < WhereToDie - WhereToDieOffset) {
			ResetGame();
		}
	}

	void ResetGame() {
		Application.LoadLevel(0);
	}
}
