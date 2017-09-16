using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public static GameController Instance;
    public GameObject GameOverText;
    public bool GameOver = false;
    private int Score = 0;
    public Text ScoreText;

    //horizontal scroll speed
    public float FlightSpeed = -1.5f;

	// Awake is called before start
	void Awake ()
    {
		if(Instance == null)
        {
            Instance = this;
        }
        else if(Instance != this)
        {
            //if theres another game controll around destroy myself. Ensures singleton pattern followed.
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(GameOver && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    //if he got through the column he didnt die ;)
    public void BirdDidntDie()
    {
        if (GameOver)
            return;

        Score++;
        ScoreText.text = string.Format("Score: {0}", Score);
    }

    public void BirdDied()
    {
        //enable game over message
        GameOverText.SetActive(true);
        GameOver = true;
    }
}
