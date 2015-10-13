using UnityEngine;
using System.Collections;

public class menuHandler : MonoBehaviour
{
    public GameObject[] menu;
    public GameObject[] menuObjs;
    public int currentMenuSelection;
    public Material selectedMat;
    public Material notSelectedMat;
    public GameObject menuCamera;
    public AudioClip selectSound;
    public AudioClip chooseSound;
    public float levelStartDelay;
    public AudioSource audioSource;

    public Color menuSelectedColor;
    public Color menuNotSelectedColor;


    public string gamelevelName;
    //0-start game, 1-high score, 2-options, 3-exit
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (currentMenuSelection > 0)
            {
                currentMenuSelection = currentMenuSelection - 1;
                updateSelection();
                audioSource.clip = selectSound;
                audioSource.Play();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (currentMenuSelection < 3)
            {
                currentMenuSelection = currentMenuSelection + 1;
                updateSelection();
                audioSource.clip = selectSound;
                audioSource.Play();
               
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (currentMenuSelection == 0)
            {
                Application.LoadLevel("loading");
            }
            else if (currentMenuSelection == 1)
            {

            }
            else if (currentMenuSelection == 2)
            {

            }
            else if (currentMenuSelection == 3)
            {
                Application.Quit();
            }
        }
	}
    
    void updateSelection()
    {
        menuCamera.GetComponent<menuCameraController>().state = currentMenuSelection;
        foreach (GameObject menuitem in menu)
        {
            if (menuitem == menu[currentMenuSelection])
            {
                menuitem.GetComponent<Renderer>().material = selectedMat;
            }
            else
            {
                menuitem.GetComponent<Renderer>().material = notSelectedMat;
            }
        }
        foreach (GameObject menuitem in menuObjs)
        {
            if (menuitem == menuObjs[currentMenuSelection])
            {
                menuitem.GetComponent<TextMesh>().color = menuSelectedColor;
            }
            else
            {
                menuitem.GetComponent<TextMesh>().color = menuNotSelectedColor;
            }
        }
    }
}
