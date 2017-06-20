using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float health = 200f;
	public GameObject laserPrefab;
	public float shootingSpeed;
	public float shotsPerSecond = 0.5f;
	public int pointsReward = 150;
	public AudioClip explosionSound;
	
	private ScoreKeeper scoreKeeper;
	private EnemySpawner enemySpawner; 
	private bool ready = false;

	void Start()
	{
		scoreKeeper = GameObject.FindObjectOfType<ScoreKeeper>();
		enemySpawner = GameObject.FindObjectOfType<EnemySpawner>();
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
		scoreKeeper.Score(pointsReward);
		Destroy(gameObject);
		AudioSource.PlayClipAtPoint(explosionSound, transform.position, 0.5f);		
	}
	
	void Update()
	{
		if (enemySpawner.ready)
		{
			Invoke("SetReady", 1);
		}
	
		float probability = shotsPerSecond * Time.deltaTime;
		if (Random.value < probability && ready)
		{
			Shoot();
		}
	}
	
	void SetReady() 
	{
		ready = true;
	}
	
	void Shoot()
	{
		GameObject laser = Instantiate(laserPrefab, transform.position + Vector3.down * 0.5f, Quaternion.identity) as GameObject;
		laser.rigidbody2D.velocity = new Vector3(0, -shootingSpeed);
		audio.Play();	
	}
}
