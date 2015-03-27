using UnityEngine;
using System.Collections;

public class carToPlayerSwitch : MonoBehaviour {


	public playerControllerSwitcher switcher;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			switcher.SwitchControl(0);
		}
	}
}
