using UnityEngine;
using System.Collections;

public class ProjectileSpeeed : MonoBehaviour {
    public float speed=-40;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody>().velocity=new Vector3(0, speed , 0);
	}
}
