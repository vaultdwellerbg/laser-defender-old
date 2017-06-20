using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Message : MonoBehaviour {

	private EnemySpawner enemySpawner;
	private Text messageUI;
	private bool visible = true;

	void Start () {
		enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
		messageUI = GetComponent<Text>();	
	}
	
	void Update () {
		if (enemySpawner.ready && visible)
		{
			messageUI.text = "Go!";
			Invoke("HideMessage", 3);
		}
		else if (!enemySpawner.ready)
		{
			visible = true;
			messageUI.text = "Get ready!";
		}
	}
	
	void HideMessage()
	{
		messageUI.text = string.Empty;
		visible = false;
	}
}
