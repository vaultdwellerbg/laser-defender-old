using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WavesDisplay : MonoBehaviour {

	void Start () {
		GetComponent<Text>().text = "You reached wave " + WavesKeeper.count.ToString();
		WavesKeeper.Reset();
	}
}
