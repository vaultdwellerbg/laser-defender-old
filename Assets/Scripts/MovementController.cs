using UnityEngine;
using System.Collections;

public class MovementController {

	private float speed;	
	private float minX;
	private float maxX;
	private Transform movedObject;
	
	public float MinX
	{
		get { return minX; }
	}
	
	public float MaxX
	{
		get { return maxX; }
	}				

	public MovementController(Transform transform, float padding, float speed)
	{
		float planeDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, planeDistance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, planeDistance));
		minX = leftmost.x + padding;
		maxX = rightmost.x - padding;
		movedObject = transform;
		this.speed = speed;
	}
	
	public void MoveLeft()
	{
		movedObject.position += Vector3.left * speed * Time.deltaTime;
		RestrictPosition();
	}
	
	public void MoveRight()
	{
		movedObject.position += Vector3.right * speed * Time.deltaTime;
		RestrictPosition();
	}	
	
	void RestrictPosition()
	{
		float clampedX = Mathf.Clamp(movedObject.position.x, minX, maxX);
		movedObject.position = new Vector3(clampedX, movedObject.position.y);		
	}		
}
