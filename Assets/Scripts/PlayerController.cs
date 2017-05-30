﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10;
	
	private float moveOffset;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			this.transform.position += new Vector3(-speed * Time.deltaTime, 0);
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			this.transform.position += new Vector3(speed * Time.deltaTime, 0);
		}
	}
}
