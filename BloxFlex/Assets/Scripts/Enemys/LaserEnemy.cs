using UnityEngine;
using System.Collections;

public class LaserEnemy : MonoBehaviour {
    public GameObject laser;
    public float delay = 10;
    public GameObject projectilePrefab;
    public GameObject projectile;
	// Use this for initialization
	void Start () {
	    laser = gameObject.transform.GetChild(0).gameObject;
        delay = Random.Range(0, delay);
        chargeLaser();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    void chargeLaser()
    {
        Vector3 temp1 = new Vector3(0, laser.transform.localScale.y, laser.transform.localScale.z);
        Vector3 temp2 = new Vector3(1, laser.transform.localScale.y, laser.transform.localScale.z);
        StartCoroutine(chargeUpLaser(0.001f, temp1, temp2));
    }
    void dechargeLaser()
    {
        Vector3 temp1 = new Vector3(1, laser.transform.localScale.y, laser.transform.localScale.z);
        Vector3 temp2 = new Vector3(0, laser.transform.localScale.y, laser.transform.localScale.z);
        StartCoroutine(dechargeUpLaser(0.001f, temp1, temp2));
    }

    void fireLaser()
    {
        projectile = Instantiate(projectilePrefab, transform.position + new Vector3(0, -2.4F, -2), Quaternion.identity) as GameObject;
        dechargeLaser();
    }

    IEnumerator chargeUpLaser(float delayTime, Vector3 sizeA, Vector3 sizeB)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            laser.transform.localScale = Vector3.Lerp(sizeA, sizeB, Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }
        fireLaser();
    }

    IEnumerator dechargeUpLaser(float delayTime, Vector3 sizeA, Vector3 sizeB)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            laser.transform.localScale = Vector3.Lerp(sizeA, sizeB, Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }
        Destroy(laser);
        GetComponent<ProjectileSpeeed>().speed = -15;
    }

}
