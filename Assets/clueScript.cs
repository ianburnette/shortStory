using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class clueScript : MonoBehaviour {

	public Transform ui, player;
	public Image image;
	public Vector3  baseScale, maxScale;
	public Vector3 currentScale, targetScale;
	public float scaleSpeed;
	public float minDistance = 2f;
	public Color unfadedColor, fadedColor;

	void Start(){

		ui.localScale = baseScale;
		player = GameObject.FindGameObjectWithTag("Player").transform.GetChild (0);
		DisableUI ();
		ui = transform.GetChild (0);
		ToggleUI (false);
	}

	public void ToggleUI(bool direction){
		//ui.gameObject.SetActive (direction);
		if (direction) {
			targetScale = maxScale;
			image.color = unfadedColor;
		} else {
			targetScale = baseScale;
		}
	}

	void Update(){
		if (ui.transform.localScale!=targetScale){
			ui.transform.localScale = Vector3.Lerp(ui.transform.localScale, targetScale, scaleSpeed * Time.deltaTime);
		}
		if (Vector3.Distance (transform.position, player.transform.position) < minDistance) {
			ui.gameObject.SetActive (true);
		} else {
			Invoke ("DisableUI", 2f);
		}
	}

	void DisableUI(){
		if (Vector3.Distance (transform.position, player.transform.position) >= minDistance) {
			image.color = fadedColor;
		}
	}
}
