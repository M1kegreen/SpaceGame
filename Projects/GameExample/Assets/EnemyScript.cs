using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	
	//Asteroid Vars
	public float startAsteroidSpeed = 10f;
	public float maxAsteroidSpeed = 20.0f;
	public float asteroidSpeedUp = 0.5f;
	public float objectHealth = 5f;
	public float asteroidRotationSpeed = 5f;
	public bool indestructible = false;
	public float maxDebrisSpeed = 10.0f;
	public float debrisRotationSpeed = 25.0f;
	public float objectDamage = 1f;
	
	//Debris Vars
	public Transform debris;
	
	private Vector3 asteroidScale;
	private Vector3 debrisPosition;
	
	private float asteroidSpeed;
	private float health;
	
		// Use this for initialization
	void Start () {
		
		//get health
		health = objectHealth;
		
		if (gameObject.tag == "Asteroid")
		{
						
			asteroidSpeed = startAsteroidSpeed + Random.Range(-1f,1f);
			
			//update debug menu
			SceneManagerScript.numberOfAsteroids++;
			
			//pick random position to start
			Vector3 temp = transform.position;
			temp.x = 12;
			temp.y = Random.Range (-6,6);
				
			//Update position
			transform.position = temp;
			
			//get scale so that we can reset to it later on
			asteroidScale = transform.localScale;

		}
		else if (gameObject.tag == "Debris") debrisPosition = new Vector3 (Random.Range(-maxDebrisSpeed,maxDebrisSpeed),Random.Range(-maxDebrisSpeed, maxDebrisSpeed),0);
		
	}
	
	// Update is called once per frame
	void Update () {
	
		if (gameObject.tag == "Asteroid") AsteroidUpdate();
		if (gameObject.tag == "Debris") DebrisUpdate ();

	}
	
	//void OnTriggerEnter(Collider other) {
	//
	//	if (gameObject.tag == "Debris") ReduceHealth(1);
	//	
	//}
	
	void AsteroidUpdate () {
	
		//move and rotate asteroid
		transform.Translate (Vector3.left * asteroidSpeed * Time.deltaTime,Space.World);
		
		transform.Rotate (debrisRotationSpeed*Time.deltaTime,debrisRotationSpeed*Time.deltaTime,debrisRotationSpeed*Time.deltaTime);
		
		//if asteroid goes off screen then reset
		if (transform.position.x <= -12)
		{
			
			//if not indestructible then reset asteroid, otherwise destroy
			if (indestructible != true) ResetMe ();
			else if (indestructible == true) Destroy (gameObject);
			
			//inc number of asteroids passed
			SceneManagerScript.numberOfAsteroids++;
			
			//speed up asteroids over time
			asteroidSpeed = asteroidSpeed + asteroidSpeedUp;
			
			//cap the max speed
			if (asteroidSpeed >= maxAsteroidSpeed) {asteroidSpeed = maxAsteroidSpeed;}
			
		}
		
	}
	
		// Move and Rotate Debris and destroy when off screen
	void DebrisUpdate () {
		
		transform.Translate (debrisPosition*Time.deltaTime,Space.World);
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
		
		if (indestructible != true) 
		{
			
			while ((damage >= 1) && (health > 0))
			{		
				
				health--;
				damage--;
				transform.localScale += new Vector3(-0.1F, -0.1f, -0.1f);
				
				if (debris)
					{
						//put explosion FX here
						Instantiate (debris,transform.position,Random.rotation);
					}
			}
			
			//print ("asteroid Health = " + health);
			
			if (health <= 0) {
				
				ResetMe();
			}
		}
		
	}
	
	//reset the gameobject to a new position, reset scale, health etc...
	void ResetMe ()
	{
			//reset asteroid's health
			health = objectHealth;
		
			transform.localScale = asteroidScale;
		
			Vector3 position = new Vector3 (Random.Range(-maxAsteroidSpeed,maxAsteroidSpeed),0,Random.Range(-maxAsteroidSpeed, maxAsteroidSpeed));
			//Vector3 position = new Vector3 (0,0,0);
			transform.Rotate (position);
		
			//temporarily hold position and reset X and Y
			Vector3 temp = transform.position;
			temp.x = 12;
			temp.y = Random.Range (-6,6);
		
			//Update position
			transform.position = temp;	
	}
	
	void OnTriggerEnter(Collider other) {
	//void OnCollisionEnter(Collision other) {
	
		if (other.gameObject.tag == "Player1")
		{
		
				//if (explosionFX)
				//{
				//	Instantiate(explosionFX,transform.position,transform.rotation);
				//}
			
				//reduce the length of the healthbar
				SceneManagerScript.gui_LoseHealth(health);
							
				ReduceHealth(health);
		}
	}
	
}
