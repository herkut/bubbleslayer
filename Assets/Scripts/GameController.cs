using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	
	public int bubbleNumber;
	public Vector3[] initialPositions;
	public Vector3[] initialVelocity;

	public GameObject bubble4x;
	public GameObject bubble2x;
	public GameObject bubble1x;

	GameObject player;
	public GameObject playerPrefab;
	public Vector3 playerPosition;

	public Button pauseButton;
	public Text lifeUi;
	public Text scoreUi;
	public GameObject menu;
	public GameObject successMenu;
	int life;
	public bool paused;
	int score;

	// Use this for initialization
	void Start () {
		life = 3;
		score = 0;
		lifeUi.text = "Life: " + life;
		scoreUi.text = "Score: " + score;
		createGameEnvironment();
	}
	void Update () 
	{
		if(Input.GetKeyDown (KeyCode.Escape))
		{
			pauseUnpause();
		}
		lifeUi.text = "Life: " + life;
		scoreUi.text = "Score: " + score;

		GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");

		if(bubbles.Length == 0 && life >= 0)
		{
			Time.timeScale = 0;
			paused = true;
			successMenu.SetActive(true);
		}

	}

	void createGameEnvironment() 
	{	
		player = (GameObject)Instantiate(playerPrefab, playerPosition, Quaternion.identity);
		for(int i = 0; i < bubbleNumber; i++)
		{
			GameObject bubble = (GameObject)Instantiate(bubble4x, initialPositions[i], Quaternion.identity);
			bubble.GetComponent<BubbleMovement>().velocity = initialVelocity[i];
			
		}
		Time.timeScale = 0;
		paused = true;
		// wait for 3 seconds
		Time.timeScale = 1;
		paused = false;
	}

	public void updateScore(int x)
	{
		score += x;
	}

	// restart game and decrease life
	public void restart()
	{
		if(life > 0)
		{
			GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");
			foreach(GameObject bubble in bubbles)
			{
				Destroy(bubble.gameObject);
			}
			GameObject[] playerClones = GameObject.FindGameObjectsWithTag("Player");
			foreach(GameObject playerClone in playerClones)
			{
				Destroy(playerClone.gameObject);
			}
			life --;
			createGameEnvironment();
		}
		else
		{
			Time.timeScale = 0;
			paused = true;
			menu.SetActive(true);
		}
		
	}

	// reload the level
	public void restartLevel()
	{
		Application.LoadLevel(0);
	}

	public void exit()
	{
		Application.Quit();
	}

	public void pauseUnpause()
	{
		if(!paused)
		{
			Time.timeScale = 0;
			paused = true;
			menu.SetActive(true);
		}
		else if(paused)
		{
			Time.timeScale = 1;
			paused = false;
			menu.SetActive(false);
		}
	}
}
