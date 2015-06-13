using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Facebook.MiniJSON;



public class MenuScript : MonoBehaviour {

	public Button facebookLoginButton;
	public Button toGameButton;

	//FB.API("me?fields=name", Facebook.HttpMethod.GET, UserCallBack);
	public string get_data;
	public string fbname;

	void Start () {
		FB.Init (ShowGui);
	}

	void ShowGui (){
		facebookLoginButton.interactable = true;
	}


	public void Login() {
		FB.Login ("", UserCallBack);
	}

	void UserCallBack(FBResult result) {
		if (result.Error != null) {                                                                      
			get_data = result.Text;
		}
		else {
			get_data = result.Text;
		}

		var dict = Json.Deserialize(get_data) as IDictionary;
		fbname = dict ["name"].ToString();
		AwesomeGlobals.fbName = fbname;

		TransitToGame ();
	}


	public void TransitToGame() {
		Application.LoadLevel (1);
	}
}
