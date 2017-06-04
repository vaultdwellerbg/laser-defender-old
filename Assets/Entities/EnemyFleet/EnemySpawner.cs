using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemyPrefab;
	public float width = 10f;
	public float height = 5f;
	public float speed = 5f;
		
	private bool moveLeft = true;	
	private MovementController movementController;

	void Start () {	
		movementController = new MovementController(transform, width / 2, speed);	
	
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate(enemyPrefab, child.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child;			
		}
	}
	
	void OnDrawGizmos()
	{
		Gizmos.DrawWireCube(transform.position, new Vector3(width, height));
	}
	
	void Update()
	{	
		if (moveLeft)
		{
			movementController.MoveLeft();	
		}
		else
		{
			movementController.MoveRight();
		}
		SwitchDirectionWhenEndReached();
	}
	
	void SwitchDirectionWhenEndReached()
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
}
