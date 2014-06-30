using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public int maxOnScreenAsteroids = 5;
	public Transform Enemy;
	public Transform indestructibleEnemy;
	public int waitTimeOfIndestructible = 5;
	
	static public int asteroidsOnScreen = 0;
	
	private float randomNumber;
	
	// Use this for initialization
	void Start () {
	
		//launch an asteroid every 2 seconds
		InvokeRepeating("LaunchEnemy", 2, 3);
		
		//I'll come up with a better way of doing this for a better flow
		InvokeRepeating("LaunchIndestructibleEnemy", 5, waitTimeOfIndestructible);		
	}
	
	// Update is called once per frame
	void Update () {		
		
	}
	
	void LaunchEnemy () {
		
		if (asteroidsOnScreen <= maxOnScreenAsteroids)
		{
			Instantiate(Enemy,transform.position,transform.rotation);
			++asteroidsOnScreen;
		}
		else if (asteroidsOnScreen > maxOnScreenAsteroids)
			{
				CancelInvoke("LaunchEnemy");
			}
	}
	
	void LaunchIndestructibleEnemy () {
		
		Instantiate(indestructibleEnemy,transform.position,transform.rotation);
	}
}
