using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	void Start () {
		GetComponent<Text>().text = ScoreKeeper.score.ToString();
		ScoreKeeper.Reset();
	}
}
