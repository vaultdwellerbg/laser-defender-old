using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float health = 200f;

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
			Destroy(gameObject);
		}		
	}
}
