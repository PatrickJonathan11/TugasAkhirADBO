using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {

	//untuk score
	public int score;
	public int highScore;
	public Text scoreText;
	public Text highScoreText;

	public PlayerController player;

	// Use this for initialization
	/// <summary>
	/// men-set score dan highscore di awal permainan
	/// </summary>
	void Start () {
		this.score =0;
		int oldHighScore = PlayerPrefs.GetInt ("HighScore");
		this.highScore = oldHighScore;
		this.highScoreText.text = "Highscore : " + highScore;

		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	/// <summary>
	/// memanggil method incScore
	/// </summary>
	void Update () {
		this.incScore ();
	}

	/// <summary>
	/// method ini digunakan untuk menambah skor saat bermain
	/// </summary>
	void incScore(){
		//score
		if(score > highScore){
			highScore = score;
			highScoreText.text = "Highscore : " + highScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
		}
		score = (int)Mathf.Round(player.transform.position.x + 8.0f);
		scoreText.text = "Score : " + score;
	}
}
