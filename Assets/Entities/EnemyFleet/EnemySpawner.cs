using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
	public float spawnDelay = 0.5f;
	public bool ready = false;
		
	private bool moveLeft = true;	
	private MovementController movementController;

	void Start () {	
		movementController = new MovementController(transform, width / 2, speed);
		SpawnUntilFull();
	}
	
	void SpawnUntilFull()
	{
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
	
	void SpawnEnemy(Transform position)
	{
		GameObject enemy = Instantiate(enemyPrefab, position.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = position;			
	}
	
	Transform NextFreePosition()
	{
		foreach (Transform positionChild in transform) {
			if(positionChild.childCount == 0) return positionChild;
		}
		return null;		
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
		foreach (Transform positionChild in transform) {
			if(positionChild.childCount > 0) return false;
		}
		return true;
	}
}
