using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthDisplay : MonoBehaviour {

	private PlayerController player;

	void Start () {
		player = GameObject.FindObjectOfType<PlayerController>();
	}
	
	void Update () {
		GetComponent<Text>().text = "Health " + player.health.ToString();
	}
}
