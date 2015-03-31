using UnityEngine;
using System.Collections;

public class junctionScript : MonoBehaviour {

	public Vector3 offset = Vector3.up * 1.5f;
	public Transform destinationBlock;
	public Transform[] destinations;
	public float rayDist;
	//public Vector3 innerCurve1Ray, innerCurve2Ray, outerCurve1Ray, outerCurve2Ray, outerCurve3Ray;
	public LayerMask junctionMask;

	// Use this for initialization
	void Start () {
		DetermineDestinations ();
	}

	void DetermineDestinations(){
		TIntersectionDeterminations ();
	}

	void TIntersectionDeterminations(){
//		Transform topLeftOfTScript = transform.GetChild (0);
//		Transform topRightOfTScript = transform.GetChild (1);
//		Transform bottomRightOfTScript = transform.GetChild (2);
//		Transform bottomLeftOfT = transform.GetChild (3);
	}


	void DrawDebugRays(){
		foreach (Transform dest in destinations) {
			Debug.DrawRay (transform.position+offset, dest.position - transform.position , Color.green);
		}
	}

	// Update is called once per frame
	void Update () {
		DrawDebugRays ();
	}

	void OnTriggerEnter(Collider coll){
		//print (coll.transform.tag);
		if (coll.transform.tag == "aiCar") {
			//print ("car entered");
			int direction = 0;
			if (destinations.Length>1){
				direction = Random.Range(0,destinations.Length);
			}
			coll.transform.parent.GetComponent<agentFollowSimple>().target = destinations[direction];
		}
	}
}
