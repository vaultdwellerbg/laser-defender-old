using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	public float padding = 1.5f;
	
	private float minX;
	private float maxX;
	private MovementController movementController;

	void Start () {
		movementController = new MovementController(transform, padding, speed);		
	}
	
	void Update () {
			
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			movementController.MoveLeft();
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			movementController.MoveRight();
		}
	}
}
