using UnityEngine;
using System.Collections;

//Player Script
public class RotationFloating : MonoBehaviour {
	
//Public Variables
public float playerSpeed = 0.5f;
public float rotationSpeed = 0.5f;
	
public float objectMaxHeight = 10.0f;
public float objectMinHeight = -10.00f;

	
//Private Variables
private bool maxHeightReached = false;
private bool minHeightReached = false;
			
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update() {
	
			//Get Key Presses etc....
		
		
			//Update Movement and Rotation of Player
			transform.Translate(0,playerSpeed * Time.deltaTime,0);//rotationSpeed * Time.deltaTime);
			transform.Rotate(0,rotationSpeed*Time.deltaTime,0);
		
			//Floaty bouncy stuff
			if (maxHeightReached == false)
			{
				if (transform.position.y > objectMaxHeight)
					{
						maxHeightReached = true;
						minHeightReached = false;
						playerSpeed = -playerSpeed;
					}
			}
			else if (maxHeightReached == true)
			{
				if (transform.position.y < objectMinHeight)
				{
					minHeightReached = true;
					maxHeightReached = false;
					playerSpeed = -playerSpeed;
				}
			}
			
    }
}
