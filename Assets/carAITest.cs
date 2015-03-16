using UnityEngine;
using System.Collections;

public class carAITest : MonoBehaviour {

	public Transform destination;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		nav.destination = destination.position;
	}
}
