using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
        public float speed;

        void FixedUpdate ()
        {
				var space = Input.GetKey ("space");
				float moveHorizontal = Input.GetAxis ("Horizontal") * Time.deltaTime;
				float moveVertical = Input.GetAxis ("Vertical") * Time.deltaTime;
				Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

				if (space) {
						rigidbody2D.velocity = movement * 0;
				} else {

						rigidbody2D.velocity = movement * speed;
				}

        }
}