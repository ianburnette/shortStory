using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerDialogueController : MonoBehaviour {

	public Transform panel;
	public Text currentName;
	public Text currentDialogue;
	public Text indicator;

	// Use this for initialization
	void Start () {
		panel.gameObject.SetActive (false);
		indicator.gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	public void SetName (string name) {
		currentName.text = name;
	}
	
	public void SetDialogueText (string textToDisplay){
		currentDialogue.text = textToDisplay;
	}

	public void ShowDialogue(){
		panel.gameObject.SetActive (true);
	}

	public void HideDialogue(){
		panel.gameObject.SetActive (false);
	}

	public void ShowIndicator(){
		indicator.gameObject.SetActive (true);
	}
	
	public void HideIndicator(){
		indicator.gameObject.SetActive (false);
	}
}