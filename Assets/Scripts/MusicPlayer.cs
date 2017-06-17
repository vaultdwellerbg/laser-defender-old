using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;
	private AudioSource music;
	
	public AudioClip[] audioClips;
	
	void Awake () 
	{
		if (instance != null && instance != this) 
		{
			GameObject.DestroyObject(gameObject);
		}
		else
		{
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);
			music = GetComponent<AudioSource>();	
			PlayClip(0);	
		}
	}
	
	void PlayClip(int index)
	{
		music.Stop();
		music.clip = audioClips[index];		
		music.Play();		
	}	
	
	void OnLevelWasLoaded(int level)
	{
		PlayClip(level);
	}
}
