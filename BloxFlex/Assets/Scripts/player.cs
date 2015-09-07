using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public Vector3 acc;
	public Vector3 max;
	public Rigidbody rb;
	public int health = 3;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.LeftArrow) || Input.GetKey (KeyCode.A)) {
			if (rb.velocity == (max * -1)) {
			}else {
				rb.velocity = rb.velocity - acc;
			}
		}

		if(Input.GetKey(KeyCode.RightArrow)||Input.GetKey (KeyCode.D)){
			if(rb.velocity==max){	
			}else {
				rb.velocity = rb.velocity + acc;
			}
		} 


	}

	void OnCollision
}
