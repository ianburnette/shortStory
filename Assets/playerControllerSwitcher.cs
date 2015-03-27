using UnityEngine;
using System.Collections;
using System;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Vehicles.Car;

public class playerControllerSwitcher : MonoBehaviour {

	public Transform fpsPlayer;
	public Transform carPlayer;
	public CarUserControl carControls;
	public Transform carCamera;
	public Vector3 playerPositionCarOffset;

	public int currentControl = 0; 
	/*
	 * 0=fps
	 * 1=car
	 * */

	// Use this for initialization
	void Start () {
		carControls = carPlayer.GetComponent<CarUserControl> ();
		carControls.enabled = false;
	}
	
	// Update is called once per frame
	public void SwitchControl (int toSwitchTo) {
		if (toSwitchTo == 0) {
			carControls.enabled = false;
			carCamera.gameObject.SetActive (false);
			fpsPlayer.gameObject.SetActive (true);
			SetPlayerPosition();
		} else if (toSwitchTo == 1) {
			fpsPlayer.gameObject.SetActive (false);
			carControls.enabled = true;
			carCamera.gameObject.SetActive (true);
		}
	}

	public void SetPlayerPosition(){
		fpsPlayer.transform.position = carPlayer.transform.position + playerPositionCarOffset;
	}
}
