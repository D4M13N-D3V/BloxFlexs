using UnityEngine;
using System.Collections;

public class spawnmanager : MonoBehaviour {

	public float spawnRate = 1.0f;
	public GameObject[] spawns;
	public GameObject[] enemyprefabs;
	void Start () {
		StartCoroutine (spawnNextCube ());
	}

	IEnumerator spawnNextCube(){
		while (true) {
			yield return new WaitForSeconds (spawnRate);
			int rdm = Random.Range (0, 4);
			if (enemyprefabs.Length == 1) {
				Instantiate (enemyprefabs [0], spawns [rdm].transform.position, Quaternion.identity);
			} else {
				int rdm2 = Random.Range (0, enemyprefabs.Length - 1);
				Instantiate (enemyprefabs [rdm2], spawns [rdm].transform.position, Quaternion.identity);
			}
		}
	}
}
