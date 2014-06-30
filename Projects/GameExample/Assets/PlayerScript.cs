using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	//public variables
	public float playerVerticalSpeed = 10f;
	public float playerHorizontalSpeed = 10f;
	public float playerTwistSpeed = 100f;
	public float bulletCount = 0.1f;
	public Transform bulletType;
	public Transform attachedTo;
	public float bobMotion = 1.0f;
	public float bobSpeed = 1.0f;
	
	//private variables
	private float horizontalPos;
	private float verticalPos;
	private float horizontalMovement;
	private float verticalMovement;
	private bool shooting = false;
	private Quaternion Temptarget;
	
	// Update is called once per frame
	void Update () {
		
		//get input from the player
		verticalPos = Input.GetAxis("Vertical") * playerVerticalSpeed * Time.deltaTime;
		horizontalPos = Input.GetAxis("Horizontal") * playerHorizontalSpeed * Time.deltaTime;
		
		//generate a bullet if key pressed
		if (shooting != true) {
			if (Input.GetKeyDown("space")) {
					InvokeRepeating("GenerateBullet", 0.01f, bulletCount);
					shooting = true;
			}
		}
		else if (Input.GetKeyUp("space")) {
				CancelInvoke("GenerateBullet");
				shooting = false;
		}
			
			//Instantiate(bulletType, attachedTo.position, attachedTo.rotation);
		
		verticalMovement = Input.GetAxis("Vertical") * playerTwistSpeed;
		horizontalMovement = Input.GetAxis("Horizontal") * playerTwistSpeed / 6;
		
		//move the player based on input
		transform.Translate(horizontalPos,verticalPos,0,Space.World);

		//blends into sideways motion
		var target = Quaternion.Euler (verticalMovement, 0, -horizontalMovement);			
		transform.rotation = Quaternion.Slerp (transform.rotation, target, Time.deltaTime * playerTwistSpeed);	
		
		//Edge of Screen Constraints		
		Vector3 tempPos = transform.position;
		
		tempPos.x = Mathf.Clamp (transform.position.x, -8f, 8f);
		tempPos.y = Mathf.Clamp (transform.position.y, -5f, 6f);
		
		transform.position = tempPos;
		
		
	}
	
	void GenerateBullet() {
	
			Instantiate (bulletType, attachedTo.position, attachedTo.rotation);
		
	}
	
	/*void OnTriggerEnter(Collider other) {
	
		//temp implentation of bulletSpeed;
		if (other.gameObject.tag == "pickup")
		{
			Destroy(other.gameObject);
			bulletCount -= 0.1f;
			CancelInvoke("GenerateBullet");
			shooting = false;
			if (bulletCount < 0.1f) bulletCount = 0.1f;
		}
		
	}
	/*/
}
