using UnityEngine;
using System.Collections;

public class carDrive : MonoBehaviour {

	public float speed, turnSpeed;
	private Rigidbody rb;
	private float h, v;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GetInput ();
		Accelerate ();
		Turn ();
	}

	void GetInput(){
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");
	}

	void Accelerate(){
		rb.AddForce (transform.forward * v * speed);
	}

	void Turn(){
		transform.Rotate (Vector3.up * h * turnSpeed);
	}
}
