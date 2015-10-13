using UnityEngine;
using System.Collections;

public class CubeHandler : MonoBehaviour {
    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
	}

    public IEnumerator destroySelf(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
