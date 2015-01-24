using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed;
	public float Xspeed;
	public float Yspeed;

	// Use this for initialization
	void Start () {
	
	}
	

	
	void FixedUpdate ()
	{

		float moveHorizontal = Xspeed * Time.deltaTime;
		float moveVertical = Yspeed * Time.deltaTime;
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody2D.velocity = movement * speed;
		
	}
}
