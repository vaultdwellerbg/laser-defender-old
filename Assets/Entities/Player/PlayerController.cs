using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	public float padding = 1.5f;
	public GameObject laserPrefab;
	public float shootingSpeed;
	public float shootingRate = 0.2f;
	
	private float minX;
	private float maxX;
	private MovementController movementController;

	void Start () {
		movementController = new MovementController(transform, padding, speed);		
	}
	
	void Update () {
		WaitForMovementInput();
		WaitForShootingInput();
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
	}
}
