using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WavesKeeper : MonoBehaviour {

	public static int count;

	public void Raise() 
	{
		count += 1;
		GetComponent<Text>().text = "Wave " + count;
	}
	
	public static void Reset()
	{
		count = 0;
	}	
}
