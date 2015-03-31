using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class playerClueDetector : MonoBehaviour {

	public Text indicator;
	public float interactDistance = 3f;
	public LayerMask clueMask;
	public Transform currentClue;
	PlayerDialogueController dialogueController;

	// Use this for initialization
	void Start () {
		currentClue = null;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position, transform.forward * interactDistance, Color.blue);
		CastRay ();
	}

	void CastRay(){
		RaycastHit hitInfo;
		Physics.Raycast (transform.position, transform.forward, out hitInfo, interactDistance, clueMask);
		//if (hitInfo.transform != null)
		//	print (hitInfo.transform);
		if (hitInfo.transform != null){// && hitInfo.transform != currentClue) {
			hitInfo.transform.GetComponent<clueDialogue>().PlayerNear();
			indicator.text = "Click to examine.";
			if (dialogueController.inDialogue){
				indicator.gameObject.SetActive(true);
			}

			currentClue = hitInfo.transform;
			currentClue.GetComponent<clueScript> ().ToggleUI (true);
		} else if (hitInfo.transform == null) {
			indicator.gameObject.SetActive(false);
			if (hitInfo.transform == null && currentClue!=null || hitInfo.transform != currentClue && currentClue!=null) {

				currentClue.GetComponent<clueScript> ().ToggleUI (false);
				hitInfo.transform.GetComponent<clueDialogue>().PlayerLeave();
				currentClue = null;
			}
		}
			
	}
}

