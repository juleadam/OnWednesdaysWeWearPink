using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public GameObject Character;

	public Text ScoreText;

	public float WhereToDieOffset = 10;
	private float WhereToDie;

	private float Score = 0f;

	void Start () {
		WhereToDie = Character.transform.position.y;
	}

	void Update () {
		if (Character.transform.position.y > Score) {
			float pos = Mathf.Round(Character.transform.position.y);
			Score = pos>Score?pos:Score;
			ScoreText.text = Score.ToString();
		}
		if (Character.transform.position.y < WhereToDie - WhereToDieOffset) {
			ResetGame();
		}
	}

	public void ResetGame() {
		Application.LoadLevel(0);
	}
}
