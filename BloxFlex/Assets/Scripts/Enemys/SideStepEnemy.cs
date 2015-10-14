using UnityEngine;
using System.Collections;

public class SideStepEnemy : MonoBehaviour
{
    public Vector3[] xposistions;
    public int pos = 1;
    bool hasMoved = false;
    public float delayTime;
    public Vector3 posA;
    public Vector3 posB;

    // Use this for initialization
    void Start()
    {
        pos = Random.Range(0, xposistions.Length);
    }

    // Update is called once per frame
    void Update()
    {
        posA = transform.position;
        posB = new Vector3(xposistions[pos].x, transform.position.y, transform.position.z);
       
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "EnemyStepEnducer")
        {
            if (!hasMoved)
            {
                int rdm = Random.Range(0, 5);
                if (rdm == 0)
                {
                    StartCoroutine(WaitAndMove(delayTime));
                    hasMoved = true;
                }
            }
        }
    }
    IEnumerator WaitAndMove(float delayTime)
    {
        yield return new WaitForSeconds(delayTime); // start at time X
        float startTime = Time.time; // Time.time contains current frame time, so remember starting point
        while (Time.time - startTime <= 1)
        { // until one second passed
            transform.position = Vector3.Lerp(posA, posB, Time.time - startTime); // lerp from A to B in one second
            yield return 1; // wait for next frame
        }
    }
}