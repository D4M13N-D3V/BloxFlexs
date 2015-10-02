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
    transform.eulerAngles = rotations[state];
    transform.position = posistions[state];
}
}