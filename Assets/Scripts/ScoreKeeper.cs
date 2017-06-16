using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

	public static int score;
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
	
	public static void Reset()
	{
		score = 0;
	}
	
	void UpdateScoreUI()
	{
		scoreUI.text = "Score: " + score;
	}
}
