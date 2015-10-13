using UnityEngine;
using System.Collections;

public class PauseButton : MonoBehaviour {
    public Animator pauseMenu;
    public bool paused = false;
    public GameObject gamemanager;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (gamemanager.GetComponent<gamemanager>().gameOver)
        {
            pauseMenu.SetTrigger("unpause");
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (paused)
            {
                UnPause();
            }
            else
            {
                Pause();
            }
        }

    }

    void pauseObjects()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("EnemyBlock");
        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    void unpauseObjects()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("EnemyBlock");
        foreach (GameObject enemy in enemys)
        {
            enemy.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    void OnMouseDown()
    {
        if (!paused)
        {
            Pause();
        }
        else
        {
            UnPause();
        }
    }


    public void Pause()
    {
        pauseMenu.SetTrigger("pause");
        paused = true;
        pauseObjects();
    }

    public void UnPause()
    {
        pauseMenu.SetTrigger("unpause");
        paused = false;
        unpauseObjects();
    }

}
