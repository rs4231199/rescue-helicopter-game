using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMEnuController : MonoBehaviour
{
	public Text BestScore1, BestScore2, BestScore3, BestScore4, BestScore5;

	void setBestScore(Text bestScore, string bestScoreString) {
		int score = PlayerPrefs.GetInt(bestScoreString, -1);
		if(score == -1)
			bestScore.text = "BestScore: ~";
		else
			bestScore.text = "BestScore: " + score.ToString();
	}
	void Start()
	{
		// Debug.Log(GameObject.FindGameObjectWithTag("Music"));
		int musicOn = PlayerPrefs.GetInt("musicOn", 1);
		if(musicOn == 1)
			GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
		else
			GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();


		// update best scores in UI
		setBestScore(BestScore1, "BestScore1");
		setBestScore(BestScore2, "BestScore2");
		setBestScore(BestScore3, "BestScore3");
		setBestScore(BestScore4, "BestScore4");
		setBestScore(BestScore5, "BestScore5");
	}
	public void levelToLoad (int level)
	{
		SceneManager.LoadScene(level);
	}
}
