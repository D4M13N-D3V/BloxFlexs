    using UnityEngine;
using System.Collections;

public class spawnmanager : MonoBehaviour {

	public float spawnRate = 1.0f;
	public GameObject[] spawns;
	public GameObject[] enemyprefabs;
    public float[] speeds;
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

                if (gamemanager.GetComponent<gamemanager>().level > 6)
                {
                    int rdm2 = Random.Range(0, 3);
                    GameObject gameobj = Instantiate(enemyprefabs[rdm2], spawns[rdm].transform.position, Quaternion.identity) as GameObject;
                    gameobj.GetComponent<ProjectileSpeeed>().speed = speeds[rdm2];
                }
                else if (gamemanager.GetComponent<gamemanager>().level > 3)
                {
                    int rdm2 = Random.Range(0, 2);
                    GameObject gameobj = Instantiate(enemyprefabs[rdm2], spawns[rdm].transform.position, Quaternion.identity) as GameObject;
                    gameobj.GetComponent<ProjectileSpeeed>().speed = speeds[rdm2];
                }
                else if (gamemanager.GetComponent<gamemanager>().level > 0)
                {
                    GameObject gameobj = Instantiate(enemyprefabs[0], spawns[rdm].transform.position, Quaternion.identity) as GameObject;
                    gameobj.GetComponent<ProjectileSpeeed>().speed = speeds[1];
                }
              //  else if(gamemanager.GetComponent<gamemanager>().level==15)
              //  {
              //      gamemanager.GetComponent<gamemanager>().gameOver = true;
              //  }
            }
        }
	}
}
