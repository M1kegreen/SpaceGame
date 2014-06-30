using UnityEngine;
using System.Collections;

public class DebrisScript : MonoBehaviour {

	public float maxDebrisSpeed = 10.0f;
	public float debrisRotationSpeed = 25.0f;
	public float debrisHealth = 1f;
	
	private Vector3 position;
	private float health;
	
		// Use this for initialization
	void Start () {
		
		health = debrisHealth;
		
		position = new Vector3 (Random.Range(-maxDebrisSpeed,maxDebrisSpeed),Random.Range(-maxDebrisSpeed, maxDebrisSpeed),0);
		
	}
	
	// Move and Rotate Debris and destroy when off screen
	void Update () {
		
		transform.Translate (position*Time.deltaTime,Space.World);
		//transform.Translate (-debrisSpeed*Time.deltaTime,0,0);
		transform.Rotate (debrisRotationSpeed*Time.deltaTime,debrisRotationSpeed*Time.deltaTime,debrisRotationSpeed*Time.deltaTime);
		
		if (transform.position.x <= -12)
		{
			Destroy(gameObject);			
		}
		else if (transform.position.x >= 12)
		{
			Destroy (gameObject);
		}
		
	}
	
		//if hit by projectile this function reduces Health of Asteroid and removes it from the game if Health reaches zero.
	public void ReduceHealth(float damage) {
		
		health -= damage;
		transform.localScale += new Vector3(-0.1F, -0.1f, -0.1f);
		
		print ("asteroid Health = " + health);
		
		if (health <= 0) {
			
			Destroy (gameObject);
		}
		
	}
	
}
