using UnityEngine;
using System.Collections.Generic;


public class terrainGenerator : MonoBehaviour {

	public int gridSize;
	public float offset = 10f;
	public List<Transform> tiles;
	public float perlinScale, heightScale, perlinOffset, verticalOffset, divisor;
	public Transform tile1;
	public bool recalc = false;

	// Use this for initialization
	void Start () {
		Generate ();
	}
	
	// Update is called once per frame
	void Update () {
		if (recalc) {
			Wipe();
			Generate();
			recalc = false;
		}
	}

	void Wipe(){
		foreach (Transform tile in transform) {
			Destroy (tile.gameObject);
		}
		tiles.Clear ();
	}

	void Generate(){
		tiles.Clear ();
		for (int i = 0; i<gridSize; i++) {
			for (int j = 0; j<gridSize; j++) {
				Transform newTile = (Transform)Instantiate(tile1,new Vector3(i,0,j), Quaternion.Euler(0,0,0));
				newTile.parent = transform;
				newTile.position = new Vector3(newTile.transform.position.x,
				                              Mathf.RoundToInt( Mathf.PerlinNoise(
													(newTile.transform.position.x + perlinOffset) * perlinScale, 
													(newTile.transform.position.z + perlinOffset) * perlinScale)
			                               			* heightScale * 2) / divisor, 
				                               newTile.transform.position.z);
				//	tiles.Add(newTile);
			}	
		}
	}
}
