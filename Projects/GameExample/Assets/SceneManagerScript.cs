using UnityEngine;
using System.Collections;

public class SceneManagerScript : MonoBehaviour {

	// variables
	private float gameSpeed = 60f;
	static int score = 0;
	static public float numberOfAsteroids = 0f;
	public Texture healthBar;
	
	public int scoreX = 10;
	public int scoreY = 10;
	public int scoreWidth = 150;
	public int scoreHeight = 20;

	public int healthX = 10;
	public int healthY = 10;
	static private float healthWidth = 150f;
	private int healthHeight = 20;
	
	static private float percentage;
	
	void Start () {
	
		percentage = healthWidth / 100f;
		
	}
	
	// game loop
	void Update () {
	
		print ("percentage = " + percentage);
		
	}
	
	static public void incrementScore () {
	
		score ++;
		
	}
	
	static public void gui_LoseHealth (float reduceHealth) {
	
		reduceHealth = reduceHealth / percentage;
		healthWidth = healthWidth - reduceHealth;
		
		if (healthWidth < 0) healthWidth = 0;
		
	}
	
	void OnGUI() {
        GUI.Label(new Rect(scoreX, scoreY, scoreWidth, scoreHeight), "Score = " + score);
		GUI.Label(new Rect(scoreX, scoreY+20, scoreWidth, scoreHeight), "Asteroid on screen = " + numberOfAsteroids);
		
		if (healthBar)
		{
				print ("drawing GUI health bar");
				GUI.DrawTexture(new Rect(healthX,healthY,healthWidth,healthHeight), healthBar, ScaleMode.ScaleAndCrop,true, 10.0f);
		}
		
		if (healthWidth == 0) GUI.Label (new Rect(50,100,scoreWidth, scoreHeight), "GAME OVER");
    }
	
}
