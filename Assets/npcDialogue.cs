using UnityEngine;
using System.Collections;

public class npcDialogue : MonoBehaviour {

	public string name;
	public string[] dialogue;
	public bool canConverse, conversing;
	int dialogueIndex = 0;
	PlayerDialogueController dialogueController;

	// Use this for initialization
	void Start () {
	
	}

	void Update(){
		DisplayButton ();
		if (Input.GetButtonDown ("Fire1")) {
			if (canConverse && !conversing){
				StartConversing();
			}else if (canConverse && conversing){
				dialogueIndex++;
				UpdateConversation();
			}
		}
	}

	void StartConversing(){
		conversing = true;
		dialogueController.ShowDialogue ();
		dialogueController.SetName (name);
		UpdateConversation ();
		dialogueController.HideIndicator();
	}

	void UpdateConversation(){
		if (dialogueIndex < dialogue.Length) {
			dialogueController.SetDialogueText (dialogue [dialogueIndex]);
		} else {
			EndConversation();
		}
	}

	void EndConversation(){
		conversing = false;
		dialogueController.HideDialogue ();
		dialogueController.ShowIndicator();
		dialogueIndex = 0;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider coll) {
		if (coll.tag == "Player") {
			canConverse = true;
			dialogueController = coll.GetComponent<PlayerDialogueController>();
			dialogueController.ShowIndicator();
			//dialogueController.ShowDialogue(name, 
		}
	}

	void OnTriggerExit (Collider coll){
		if (coll.tag == "Player") {
			canConverse = false;
			EndConversation();
			dialogueController.HideIndicator();
		}
	}

	void DisplayButton(){
		if (canConverse && !conversing) {
			//show button
		}
	}
}
