using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
        public float dampTime90 = .2f;
        private Animator animator;
        public bool diagonal;
        public int speed;
        // Use this for initialization
        void Start ()
        {
                animator = this.GetComponent<Animator> ();

        }
    
        // Update is called once per frame
        void Update ()
        {

                var vertical = Input.GetAxis ("Vertical");
                var horizontal = Input.GetAxis ("Horizontal");

                if (horizontal == 0 && vertical == 0) {
                        speed = 0;
                        animator.SetFloat ("speed", speed);
                } else {
                        speed = 1;
                        animator.SetFloat ("speed", speed);
            
                }

                if (speed > 0) {
                        Vector2 normalizedVelocity = transform.parent.rigidbody2D.velocity.normalized;

                        Vector2 controlVector = Mathf.Approximately (normalizedVelocity.sqrMagnitude, 0.0f) ? new Vector2 () : new Vector2 (normalizedVelocity.x + 0.05f, normalizedVelocity.y + 0.05f);
                        //Debug.Log (controlVector.ToString ());
                        animator.SetFloat ("velocityY", controlVector.y, dampTime90, Time.deltaTime);
                        animator.SetFloat ("velocityX", controlVector.x, dampTime90, Time.deltaTime);
        
                }
//
//              if ((horizontal < 0 && vertical < 0) | (horizontal > 0 && vertical < 0) | (horizontal > 0 && vertical > 0) | (horizontal < 0 && vertical > 0)) {
//                      diagonal = true;
//              } else {
//                      diagonal = false;
//              }
//
//              if (diagonal == false) {
//
//                      if (vertical > 0) {
//                              animator.SetFloat ("velocityY", 1, dampTime90, Time.deltaTime);
//                              animator.SetFloat ("velocityX", 0, dampTime90, Time.deltaTime);
//                              print ("north");
//                      } else if (vertical < 0) {
//                              animator.SetFloat ("velocityY", -1, dampTime90, Time.deltaTime);
//                              animator.SetFloat ("velocityX", 0, dampTime90, Time.deltaTime);
//                              print ("south");
//                      } else if (horizontal > 0) {
//                              animator.SetFloat ("velocityX", 1, dampTime90, Time.deltaTime);
//                              animator.SetFloat ("velocityY", 0, dampTime90, Time.deltaTime);
//                              print ("east");
//                      } else if (horizontal < 0) {
//                              animator.SetFloat ("velocityX", -1, dampTime90, Time.deltaTime);
//                              animator.SetFloat ("velocityY", 0, dampTime90, Time.deltaTime);
//                              print ("west");
//                      }
//              }
//              if (diagonal == true) {
//
//                      if (horizontal < 0 && vertical < 0) {
//                              animator.SetFloat ("velocityX", -.5f, dampTime90, Time.deltaTime);
//                              animator.SetFloat ("velocityY", -.5f, dampTime90, Time.deltaTime);
//                              print ("southwest");
//                      } else if (horizontal > 0 && vertical < 0) {
//                              animator.SetFloat ("velocityX", .5f, dampTime90, Time.deltaTime);
//                              animator.SetFloat ("velocityY", -.5f, dampTime90, Time.deltaTime);
//                              print ("southeast");
//                      } else if (horizontal > 0 && vertical > 0) {
//                              animator.SetFloat ("velocityX", .5f, dampTime90, Time.deltaTime);
//                              animator.SetFloat ("velocityY", .5f, dampTime90, Time.deltaTime);
//                              print ("northeast");
//                      } else if (horizontal < 0 && vertical > 0) {
//                              animator.SetFloat ("velocityX", -.5f, dampTime90, Time.deltaTime);
//                              animator.SetFloat ("velocityY", .5f, dampTime90, Time.deltaTime);           
//                              print ("nortwest");
//                      }
//              }
//
//

        }
}