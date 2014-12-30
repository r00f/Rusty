using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour
{
        public float speed;
    
        void FixedUpdate ()
        {
                float moveHorizontal = Input.GetAxis ("Horizontal") * Time.deltaTime;
                float moveVertical = Input.GetAxis ("Vertical") * Time.deltaTime;
//      if (Mathf.Approximately(moveHorizontal, 0.0f) && Mathf.Approximately(moveVertical, 0.0f)) {
//          rigidbody2D.velocity = new Vector2();
//      } else {
                Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
                rigidbody2D.velocity = movement * speed;
//      }
        }
}