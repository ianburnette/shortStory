using UnityEngine;
using System.Collections;

public class GroundChooser : MonoBehaviour {

	public LayerMask groundMask;
	public Transform[] groundTiles;
	public Transform rh, lh, fh, bh;
	public RaycastHit rightHit, leftHit, forwardHit, backHit;

	/*
		0 = flat
		1 = hill
		2 = concave hill
		3 = convex hill
		4 = peak
		5 = valley
	 */

	// Use this for initialization
	void Start () {
		CheckAround ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawRay (transform.position + Vector3.right, new Vector3(1.1f,0,0), Color.red); 
		Debug.DrawRay (transform.position + Vector3.forward, Vector3.forward/3, Color.green); 
		Debug.DrawRay (transform.position + Vector3.left, Vector3.left/3, Color.blue); 
		Debug.DrawRay (transform.position + Vector3.back, Vector3.back/3, Color.yellow); 
	}

	void CheckAround(){

		print ("checking");
		Physics.Raycast (transform.position + Vector3.right, transform.position + new Vector3 (1.1f,0,0), out rightHit, .3f);
		Physics.Raycast (transform.position + Vector3.left, -transform.right, out leftHit, .3f);
		Physics.Raycast (transform.position + Vector3.forward, transform.forward, out forwardHit, .3f);
		Physics.Raycast (transform.position + Vector3.back, -transform.forward, out backHit, .3f);

		rh = rightHit.transform;
		lh = leftHit.transform;
		fh = forwardHit.transform;
		bh = backHit.transform;

		//all sides blocked 
		if (rightHit.transform!=null && leftHit.transform!=null && forwardHit.transform!=null && backHit.transform!=null){
			CreateTile(groundTiles[0], new Vector3(90,0,0));
		}
		//right side blocked
		if (rightHit.transform!=null && leftHit.transform==null && forwardHit.transform==null && backHit.transform == null){
			CreateTile(groundTiles[0], new Vector3(90,90,0));
		}
	}

	void CreateTile(Transform tileToCreate, Vector3 rotationForTile){
		print ("Destroyed");
		Destroy (transform.GetChild (0).gameObject);
		Instantiate (tileToCreate, transform.position, Quaternion.Euler (rotationForTile));
	}
}
