using UnityEngine;
using UnityEngine.UI;

public class ChargerScript : MonoBehaviour {

	Image _chargeBar;

	void Start () {
		JumpingScript.OnCharge += Charge;
		JumpingScript.OnJump += ResetCharge;
		_chargeBar = GetComponent<Image> ();
		ResetCharge (0);
	}

	void Charge(float chargeAmount) {
		Debug.Log ("Chargeamount " + chargeAmount);
		_chargeBar.fillAmount = chargeAmount;
	}

	void ResetCharge(float dontuse) {
		_chargeBar.fillAmount = 0;
	}

	void OnDestroy() {
		UnsubscribeEvents ();
	}

	void UnsubscribeEvents() {
		JumpingScript.OnCharge -= Charge;
		JumpingScript.OnJump -= ResetCharge;
	}


	

}
