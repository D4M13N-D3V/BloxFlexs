using UnityEngine;
using System.Collections;

public class enemyscaledelete : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Despawn(){
		StartCoroutine (scaleDestroy (transform.localScale, new Vector3(0,0,0), 0.5f));
		GetComponent<Rigidbody> ().isKinematic = true;
		GetComponent<BoxCollider> ().enabled = false;
	}

	IEnumerator scaleDestroy(Vector3 source, Vector3 target, float overTime)
	{
		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{
			transform.localScale = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}
		transform.localScale = target;
		Destroy (gameObject);
	}
}


