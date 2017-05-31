using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 10f;
	public float padding = 1.5f;
	
	private float minX;
	private float maxX;

	void Start () {
		float planeDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftmost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, planeDistance));
		Vector3 rightmost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, planeDistance));
		minX = leftmost.x + padding;
		maxX = rightmost.x - padding;
	}
	
	void Update () {
			
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		else if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
		RestrictShipPosition();
	}
	
	void RestrictShipPosition()
	{
		float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
		transform.position = new Vector3(clampedX, transform.position.y);		
	}
}
