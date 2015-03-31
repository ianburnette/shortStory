using UnityEngine;
using System.Collections;

public class lookAtPlayer : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("Player").transform.GetChild (0);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target.position);
	}
}
