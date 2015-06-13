using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

	public Button facebookLoginButton;
	public Button toGameButton;

	void Start () {
		FB.Init (ShowGui);
	}

	void ShowGui (){
		facebookLoginButton.interactable = true;
	}


	public void Login() {
		FB.Login ("", TransitToGame);
	}


	void TransitToGame (FBResult result) {
		Application.LoadLevel (1);
	}

	public void TransitToGame() {
		Application.LoadLevel (1);
	}
}
