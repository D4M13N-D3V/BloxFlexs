using UnityEngine;
using System.Collections;

public class CubeSpawnManager : MonoBehaviour {
    public GameObject[] cubeVarietys;
    public GameObject[] cubeSpawnPoints;
    public float cubeSpeed;
    public float selfDestroyTime;
    public float cubeSpawnRate;

	void Start () {
        StartCoroutine(spawnCubeTimer());
	}
	
	void Update () {
	
	}

    IEnumerator spawnCubeTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(cubeSpawnRate);
            spawnCube();
            spawnCube();
            spawnCube();
        }
    }

    public void spawnCube()
    {
        int rng = Random.Range(0, cubeSpawnPoints.Length);
        Vector3 spawnpos = cubeSpawnPoints[rng].transform.position;
        Vector3 angles = cubeSpawnPoints[rng].transform.eulerAngles;
        rng = Random.Range(0, cubeVarietys.Length);
        GameObject temp = Instantiate(cubeVarietys[rng], spawnpos, Quaternion.identity) as GameObject;
        temp.transform.eulerAngles = angles;
        temp.GetComponent<CubeHandler>().speed = cubeSpeed;
        StartCoroutine(temp.GetComponent<CubeHandler>().destroySelf(selfDestroyTime));
    }
}
