using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
	public float speed;
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal") * Time.deltaTime;
		float moveVertical = Input.GetAxis ("Vertical") * Time.deltaTime;
		
		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		rigidbody2D.velocity = movement * speed;

	}
}