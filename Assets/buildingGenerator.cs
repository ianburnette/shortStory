using UnityEngine;
using System.Collections;

public class buildingGenerator : MonoBehaviour {

	public Transform[] baseTiles, wallTiles, roofTiles, awningTiles;
	public int[] baseIndices, wallIndicies;
	public int floors, roofIndex, awningIndex;
	public Vector3[] basePositions;
	public Transform[] bases;
	public Transform basePrefab;
	public Transform floorPrefab;
	public Transform roofPrefab;
	public float floorOffset;

	// Use this for initialization
	void Start () {
		floors = Random.Range (3, 20);
		SelectIndices ();
		CreatePieces ();
	}

	void SelectIndices(){
		for (int i = 0; i<4; i++) {
			baseIndices[i] = Random.Range (0, baseTiles.Length);
		}

//		for (int f = 0; f<floors; f++) {
//			for (int i = 0; i<4; i++) {
//				wallIndicies[i] = Random.Range (0, baseTiles.Length);
//			}
//		}

		roofIndex = Random.Range (0, roofTiles.Length);
		awningIndex = Random.Range (0, awningTiles.Length);

	}

	void CreatePieces(){
		for (int i = 0; i<floors+1; i++) {
			if (i==0){
				Transform floor = (Transform)Instantiate(basePrefab, new Vector3(transform.position.x, transform.position.y+(floorOffset * (i+1)), transform.position.z), Quaternion.identity);
				floor.transform.parent = transform;
			}
			else if (i==floors){
				Transform floor = (Transform)Instantiate(roofPrefab, new Vector3(transform.position.x, transform.position.y+(floorOffset * (i+1)), transform.position.z), Quaternion.identity);
				floor.transform.parent = transform;
			}else{
				Transform floor = (Transform)Instantiate(floorPrefab, new Vector3(transform.position.x, transform.position.y+(floorOffset * (i+1)), transform.position.z), Quaternion.identity);
				floor.transform.parent = transform;
			}
//			bases[i] = (Transform)Instantiate (baseTiles [baseIndices[i]], transform.position + basePositions[i], Quaternion.identity);
//			bases[i].parent = transform;
		}

	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i<4; i++) {
//bases[i].position = transform.position + basePositions[i];
		}
	}
}
