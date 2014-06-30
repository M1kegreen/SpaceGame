using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	public float bulletSpeed = 5.0f;
	public float timeToDestroy = 3.0f;
	public Transform explosionFX;
	public float bulletDamage = 1f;
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(bulletSpeed*Time.deltaTime, 0, 0);
		
		Destroy (gameObject, timeToDestroy);
		
	}
	
		
	void OnTriggerEnter(Collider other) {
        
		//print ("We hit something");
		
			if ((other.gameObject.tag == "Asteroid") || (other.gameObject.tag == "Debris"))
		{
		
				if (explosionFX)
				{
					Instantiate(explosionFX,transform.position,transform.rotation);
				}
	       	 	
				SceneManagerScript.incrementScore();
				
				EnemyScript test = other.GetComponent<EnemyScript>();
			
				if (test != null) test.ReduceHealth(bulletDamage);
				
				//if (other.GetComponent<EnemyScript>())
	            //		other.GetComponent<EnemyScript>().ReduceHealth();
				
				Destroy(gameObject);
		}	
		
    }	
	//	void UpdateScore ()
	//{
	//SceneManagerScript sceneManagerScript = GetComponent<SceneManagerScript>();
    //    sceneManagerScript.incrementScore();
	//}
	
}
