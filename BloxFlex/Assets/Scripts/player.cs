using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {
	
	public Vector3 acc;
	public Vector3 max;
	public Rigidbody rb;
	public int health = 3;
    public GameObject gameover;
	public GameObject[] healthbars;
    public GameObject gamemanager;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}


	// Update is called once per frame
	void Update () {
        if (!gamemanager.GetComponent<gamemanager>().gameOver)
        {
            if (health == 3)
            {
            }
            else if (health == 2)
            {
                ;
                healthbars[2].transform.localScale = Vector3.Lerp(healthbars[2].transform.localScale, new Vector3(0, 0, 0), Time.deltaTime * 5);
            }
            else if (health == 1)
            {
                healthbars[2].transform.localScale = Vector3.Lerp(healthbars[2].transform.localScale, new Vector3(0, 0, 0), Time.deltaTime * 5);
                healthbars[1].transform.localScale = Vector3.Lerp(healthbars[1].transform.localScale, new Vector3(0, 0, 0), Time.deltaTime * 5);
            }
            else if (health == 0)
            {
                healthbars[2].transform.localScale = Vector3.Lerp(healthbars[2].transform.localScale, new Vector3(0, 0, 0), Time.deltaTime * 5);
                healthbars[1].transform.localScale = Vector3.Lerp(healthbars[1].transform.localScale, new Vector3(0, 0, 0), Time.deltaTime * 5);
                healthbars[0].transform.localScale = Vector3.Lerp(healthbars[0].transform.localScale, new Vector3(0, 0, 0), Time.deltaTime * 5);
            }

            //47.74012-22.6

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (rb.velocity == (max * -1))
                {
                }
                else
                {
                    rb.velocity = rb.velocity - acc;
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (rb.velocity == max)
                {
                }
                else
                {
                    rb.velocity = rb.velocity + acc;
                }
            }
            else
            {
                rb.velocity = new Vector3(0, 0, 0);
            }
        }

		


	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "EnemyBlock") {
			if(health>0){
				health = health-1;

			}else{
                //GAMEOVER
                gameover.GetComponent<Animator>().SetTrigger("gameOver");
                gamemanager.GetComponent<gamemanager>().gameOver = true;
			}
			collision.gameObject.GetComponent<enemyscaledelete>().Despawn();
		}
	}

	IEnumerator scaleDestroy(GameObject obj ,Vector3 source, Vector3 target, float overTime)
	{
		float startTime = Time.time;
		while(Time.time < startTime + overTime)
		{
						obj.transform.localScale = Vector3.Lerp(source, target, (Time.time - startTime)/overTime);
			yield return null;
		}
		obj.transform.localScale = target;
	}
}
