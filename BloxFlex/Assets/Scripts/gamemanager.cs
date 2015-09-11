using UnityEngine;
using System.Collections;

public class gamemanager : MonoBehaviour {
	public float spawnRate = 0.5F;
	public float enemySpeed = 1;
	public GameObject spawnManager;
	public Vector3 playerMaxSpeed = new Vector3(10,0,0);
	public Vector3 playerSpeed = new Vector3(5,0,0);
	public GameObject player;
	public int score = 0;
	public int nextLevelScore=10;
	public int level = 1;
	public GameObject scoretext;
	public GameObject leveltext;

	void Start(){
		updateLevel ();
		updateScore();
		updatePlayer();
	}

	public void updateScore(){
		scoretext.GetComponent<TextMesh> ().text = (score).ToString ();
	}

	public void updateLevel(){
		leveltext.GetComponent<TextMesh> ().text = "LVL - "+(level).ToString ();
	}

	public void updateEnemys(){
		spawnManager.GetComponent<spawnmanager> ().speed = enemySpeed;
		spawnManager.GetComponent<spawnmanager> ().spawnRate = spawnRate;
	}

	public void updatePlayer(){
		player.GetComponent<player> ().acc = playerSpeed;
		player.GetComponent<player> ().max = playerMaxSpeed;
	}

	public void addScore(int amount){
		score = score + amount;
		updateScore ();
		if (score == nextLevelScore) {
			level=level+1;
			nextLevelScore = (level*5)*2;
			enemySpeed=enemySpeed+0.5f;
			spawnRate=spawnRate+0.05f;
			playerMaxSpeed.x=playerMaxSpeed.x+0.05f;
			playerSpeed.x=playerSpeed.x+0.05f;
			updateLevel();
			updateEnemys();
			updatePlayer();
		}
	}
	// LEVEL MANAGER -------------------------------------------------------------------------------------------------------------------------


}
