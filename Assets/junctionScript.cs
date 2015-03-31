using UnityEngine;
using System.Collections;

public class junctionScript : MonoBehaviour {

	public Vector3 offset = Vector3.up * 1.5f;
	public Transform[] destinations;

	// Use this for initialization
	void Start () {
		DetermineDestinations ();
	}

	void DetermineDestinations(){
		if (transform.name == "topRightOfT") {
			destinations = new Transform[2];
			RaycastHit hitInfo;
			Physics.Raycast(transform.position + offset, (-transform.right), out hitInfo, 3f);
			destinations[0] = hitInfo.transform;
			Physics.Raycast(transform.position + offset, (-transform.right + transform.up), out hitInfo, 4f);
			destinations[1] = hitInfo.transform;
		}if (transform.name == "topLeftOfT") {
			destinations = new Transform[1];
			RaycastHit hitInfo;
			Physics.Raycast(transform.position + offset, -transform.right, out hitInfo, 50f);
			destinations[0] = hitInfo.transform;
		}
	}	

	// Update is called once per frame
	void Update () {
		if (transform.name == "topLeftOfT") {
			Debug.DrawRay (transform.position + offset, -transform.right * 100f, Color.yellow);
		}if (transform.name == "topRightOfT") {
			Debug.DrawRay (transform.position + offset, -transform.right *3f, Color.yellow);
			Debug.DrawRay (transform.position + offset, (-transform.right + transform.up) *3f, Color.yellow);
			RaycastHit hitInfo;
			Physics.Raycast(transform.position + offset, (-transform.right), out hitInfo, 3f);
			print (hitInfo.transform);
		}if (transform.name == "bottomRightOfT") {
			Debug.DrawRay (transform.position + offset, -transform.up * 2f, Color.yellow);
			Debug.DrawRay (transform.position + offset, transform.right * 100f, Color.yellow);
			//Debug.DrawRay (transform.position + offset, (-transform.right + transform.up) *3f, Color.yellow);
		}if (transform.name == "bottomLeftOfT") {
			Debug.DrawRay (transform.position + offset, transform.right * 2f, Color.yellow);
			Debug.DrawRay (transform.position + offset, transform.up * 100f, Color.yellow);
		}


	}

	void OnTriggerEnter(Collider coll){
		//print (coll.transform.tag);
		if (coll.transform.tag == "aiCar") {
			print ("car entered");
			int direction = 0;
			if (destinations.Length>1){
				direction = Random.Range(0,destinations.Length);
			}
			coll.transform.parent.GetComponent<agentFollowSimple>().target = destinations[direction];
		}
	}
}
