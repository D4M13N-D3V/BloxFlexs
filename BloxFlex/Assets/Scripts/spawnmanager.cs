using UnityEngine;
using System.Collections;

public class spawnmanager : MonoBehaviour {

	public float spawnRate = 1.0f;
	public float speed = 1.0f;
	public GameObject[] spawns;
	public GameObject[] enemyprefabs;
    public GameObject gamemanager;
    public GameObject[] spawnedincubes;
    public GameObject pausebutton;
	void Start () {
		StartCoroutine (spawnNextCube ());
	}

	IEnumerator spawnNextCube(){
        while (!gamemanager.GetComponent<gamemanager>().gameOver)
        {

            yield return new WaitForSeconds(spawnRate);
            if (!pausebutton.GetComponent<PauseButton>().paused)
             {
            int rdm = Random.Range(0, 6);
                if (enemyprefabs.Length == 1)
                {
                    GameObject gameobj = Instantiate(enemyprefabs[0], spawns[rdm].transform.position, Quaternion.identity) as GameObject;
                    gameobj.GetComponent<Rigidbody>().AddForce(-Vector3.up * (speed * 4));
                }
                else
                {
                    int rdm2 = Random.Range(0, enemyprefabs.Length - 1);
                    GameObject gameobj = Instantiate(enemyprefabs[rdm2], spawns[rdm].transform.position, Quaternion.identity) as GameObject;
                    gameobj.GetComponent<Rigidbody>().AddForce(-Vector3.up * (speed * 4));
                }
            }
        }
	}
}
