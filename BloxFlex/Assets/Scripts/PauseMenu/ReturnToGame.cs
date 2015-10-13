using UnityEngine;
using System.Collections;

public class ReturnToGame : MonoBehaviour {

    public GameObject pausebutton;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

    }

    void OnMouseDown()
    {
        pausebutton.GetComponent<PauseButton>().UnPause();
    }
}
