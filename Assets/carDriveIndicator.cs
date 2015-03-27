using UnityEngine;
using System.Collections;

public class carDriveIndicator : MonoBehaviour {

	PlayerCarUIController uiController;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {

			uiController = coll.GetComponent<PlayerCarUIController>();
			uiController.ShowIndicator();
			//dialogueController.ShowDialogue(name, 
		}
	}
	
	void OnTriggerExit (Collider coll){
		if (coll.tag == "Player") {
			uiController.HideIndicator();
		}
	}
}
