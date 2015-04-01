using UnityEngine;
using System.Collections;

public class junctionMasterScript : MonoBehaviour {

	public Transform[] junctions;
	public Transform[] nearbyJunctions;
	public int childCount;

	// Use this for initialization
	void Start () {
		junctions = new Transform[5];
		childCount = transform.childCount;
		for (int i = 0; i<childCount; i++) {
			junctions[i] = transform.GetChild(i);
		}
		SetupJunctionAssociations ();
	}
	
	// Update is called once per frame
	void Update () {
		DrawJunctionLines ();
	}

	void DrawJunctionLines(){

	}

	void SetupJunctionAssociations(){
		if (transform.tag == "junction3way"){
			for (int i = 0; i<nearbyJunctions.Length; i++){
				
			}
			foreach (Transform nearbyJunction in nearbyJunctions) {
				if (nearbyJunction.tag == "junctionCurve"){
					junctions[0].GetComponent<junctionScript>().destinations[0] = nearbyJunction.GetChild(0);
					//junctions[1]
				}
			}
		}
	}
}
