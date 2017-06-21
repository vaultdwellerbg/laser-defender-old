﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;
	public bool ready = false;
		
	private bool moveLeft = true;	
	private MovementController movementController;
	private WavesKeeper wavesKeeper;
	private List<Transform> freePositions;
	
	private const int MIN_ENEMY_COUNT = 5;
	private const int ENEMY_COUNT_PROGRESSION_RATE = 2;

	void Start () {	
		movementController = new MovementController(transform, width / 2, speed);
		wavesKeeper = GameObject.FindObjectOfType<WavesKeeper>();
		wavesKeeper.Raise();	
		SpawnUntilFull();
	}
	
	void SpawnUntilFull()
	{
		InitFreePositions();
		Transform freePosition = NextFreePosition();
		if (freePosition)
		{
			SpawnEnemy(freePosition);
			Invoke("SpawnUntilFull", spawnDelay);
		}
		else
		{
			ready = true;
		}
	}
	
	void InitFreePositions()
	{
		freePositions = new List<Transform>();
		int maxEnemyCount = GetMaxEnemyCount();
		for (int i = 0; i < maxEnemyCount; i++) {
			freePositions.Add(transform.GetChild(i));
		}		
	}
	
	int GetMaxEnemyCount()
	{
		int count = MIN_ENEMY_COUNT + WavesKeeper.count / ENEMY_COUNT_PROGRESSION_RATE;
		return Mathf.Clamp(count, 0, transform.childCount);		
	}
	
	Transform NextFreePosition()
	{
		foreach (Transform positionChild in freePositions) {
			if (positionChild.childCount == 0) return positionChild;
		}
		return null;		
	}		
	
	void SpawnEnemy(Transform position)
	{
		GameObject enemy = Instantiate(enemyPrefab, position.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = position;			
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	void Update()
	{	
		MoveEnemies();
		SwitchDirectionWhenEdgeReached();	
		if (AllEnemiesDestroyed())
		{
			ready = false;
			wavesKeeper.Raise();
			SpawnUntilFull();
		}
	}
	
	void MoveEnemies()
	{
		if (moveLeft)
		{
			movementController.MoveLeft();	
		}
		else
		{
			movementController.MoveRight();
		}		
	}
	
	void SwitchDirectionWhenEdgeReached()
	{
		if (transform.position.x <= movementController.MinX)
		{
			moveLeft = false;
		}
		else if (transform.position.x >= movementController.MaxX)
		{
			moveLeft = true;
		}
	}
	
	bool AllEnemiesDestroyed()
	{
		foreach (Transform positionChild in freePositions) {
			if (positionChild.childCount > 0) return false;
		}
		return true;
	}
}
