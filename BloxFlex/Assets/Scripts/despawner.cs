using UnityEngine;
using System.Collections;

public class despawner : MonoBehaviour {
	public GameObject gameManager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider coll ) {
		if (coll.tag == "Enemy") {
			coll.gameObject.GetComponent<enemyscaledelete>().Despawn();
			gameManager.GetComponent<gamemanager>().addScore(1);
		}
	}
}
