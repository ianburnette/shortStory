using UnityEngine;
using System.Collections;

public class agentFollowSimple : MonoBehaviour {

	public Transform destination;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		agent.destination = destination.position;
	}
}
