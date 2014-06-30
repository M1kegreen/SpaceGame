using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

public int movementSpeed = 10;
public int rotationSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKey(KeyCode.W)) 
		{
			rigidbody.AddRelativeForce (movementSpeed, 0, 0);
		}
		if (Input.GetKey(KeyCode.S)) 
		{
			rigidbody.AddRelativeForce (-movementSpeed, 0, 0);
		}
		if (Input.GetKey(KeyCode.A)) 
		{
			rigidbody.AddTorque (0,-rotationSpeed,0);
		}
		if (Input.GetKey(KeyCode.D)) 
		{
			rigidbody.AddTorque (0,rotationSpeed,0);
		}

		if (Input.GetKey (KeyCode.Space)) {
			rigidbody.AddRelativeForce (0,movementSpeed/2,0);
				}
	}
}
