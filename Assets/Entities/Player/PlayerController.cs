﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	public float padding = 1.5f;
	public GameObject laserPrefab;
	public float shootingSpeed;
	public float shootingRate = 0.2f;
	public float health = 300f;
	public AudioClip explosionSound;
	
	private float minX;
	private float maxX;
	private MovementController movementController;
	private LevelManager levelManager;
	private EnemySpawner enemySpawner; 

	void Start () {
		movementController = new MovementController(transform, padding, speed);
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
	}
	
	void Update () {
		if (enemySpawner.ready)
		{
			WaitForMovementInput();
			WaitForShootingInput();			
		}
		else
		{
			CancelInvoke("Shoot");
		}
	}
	
	void WaitForMovementInput()
	{
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			movementController.MoveLeft();
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			movementController.MoveRight();
		}		
	}
	
	void WaitForShootingInput()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			InvokeRepeating("Shoot", 0.000001f, shootingRate);
		}
		else if (Input.GetKeyUp(KeyCode.Space))
		{
			CancelInvoke("Shoot");
		}
	}
	
	void Shoot()
	{
		GameObject laser = Instantiate(laserPrefab, transform.position + Vector3.up * 0.5f, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0, shootingSpeed);
		audio.Play();
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		Projectile projectile = col.gameObject.GetComponent<Projectile>();
		if (projectile != null)
		{
			TakeDamage(projectile.Damage);
			projectile.Hit();
		}
	}
	
	void TakeDamage(float damage)
	{
		health -= damage;
		if (health <= 0)
		{
			Explode();
		}		
	}	
	
	void Explode()
	{
	 	GetComponent<SpriteRenderer>().sprite = null;
		AudioSource.PlayClipAtPoint(explosionSound, transform.position, 0.5f);
		Invoke("EndGame", 3f);
		Destroy(gameObject, 3.1f);		
	}
	
	void EndGame()
	{
		levelManager.LoadLevel("End");
	}
}
