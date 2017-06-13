using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	private int score;
	private Text scoreUI;

	void Start()
	{
		scoreUI = GetComponent<Text>();
	}

	public void Score(int points)
	{
		score += points;
		UpdateScoreUI();
	}
	
	public void Reset()
	{
		score = 0;
		UpdateScoreUI();
	}
	
	void UpdateScoreUI()
	{
		scoreUI.text = "Score: " + score;
	}
}
