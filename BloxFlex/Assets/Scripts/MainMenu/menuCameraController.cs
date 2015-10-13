using UnityEngine;
using System.Collections;

public class menuCameraController : MonoBehaviour 
{
public int state;
public Vector3[] rotations;
public Vector3[] posistions;

// Use this for initialization
void Start()
{

}

// Update is called once per frame
void Update()
    {
        //transform.eulerAngles = Vector3.Lerp(transform.eulerAngles,rotations[state], 0.1f);
        // transform.position = Vector3.Lerp(transform.position,posistions[state], 0.1f);
        transform.eulerAngles =         rotations[state];
        transform.position = posistions[state];
    }




}