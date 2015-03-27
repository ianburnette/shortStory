using UnityEngine;
using System.Collections;

public class PlayerCarUIController : MonoBehaviour {

	public Transform carIndicator;
	bool canEnterCar = false;
	public playerControllerSwitcher switcher;

	// Use this for initialization
	void Start () {
		carIndicator.gameObject.SetActive (false);
	}

	void Update(){
		if (canEnterCar && Input.GetButtonDown ("Fire1")) {
			EnterCar();
		}
	}

	public void ShowIndicator () {
		carIndicator.gameObject.SetActive (true);
		canEnterCar = true;
	}

	public void HideIndicator() {
		carIndicator.gameObject.SetActive (false);
		canEnterCar = false;
	}

	void EnterCar(){
		switcher.SwitchControl (1);
	}
}
