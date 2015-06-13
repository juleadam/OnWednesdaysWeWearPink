using UnityEngine;
using UnityEngine.UI;

public class FacebookStuff : MonoBehaviour {

	void Start () {

		if (FB.IsLoggedIn) {
			GetComponent<Text> ().text = AwesomeGlobals.fbName;
		}
	}

}
