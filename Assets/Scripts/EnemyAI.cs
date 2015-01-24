using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{

		Transform target;
		Transform enemyTransform;
		private EnemyMovement enemyMove;
		public float speed = 1f;
		private Animator animator;
		public float dampTime90 = .2f;

		void Start ()
		{
				animator = this.GetComponent<Animator> ();
				enemyMove = this.GetComponentInParent<EnemyMovement> ();
		}

		void FixedUpdate ()
		{
				target = GameObject.FindWithTag ("Player").transform;
				enemyTransform = this.transform;
		}

		void Update ()
		{

				if (enemyTransform.position.x == target.position.x) {

						enemyMove.Xspeed = 0;

				} else if (enemyTransform.position.x < target.position.x) {
						
						enemyMove.Xspeed = 1;

				} else if (enemyTransform.position.x > target.position.x) {
			
						enemyMove.Xspeed = -1;
				}


				if (enemyTransform.position.y == target.position.y) {

						enemyMove.Yspeed = 0;

				} else if (enemyTransform.position.y < target.position.y) {
			
						enemyMove.Yspeed = 1;

				} else if (enemyTransform.position.y > target.position.y) {
			
						enemyMove.Yspeed = -1;
				}			

				if (enemyTransform.position.x == target.position.x && enemyTransform.position.y == target.position.y) {
						speed = 0;
				} 


				animator.SetFloat ("speed", speed);
		
		
		
				if (speed > 0) {

						Vector2 normalizedVelocity = transform.parent.rigidbody2D.velocity.normalized;
			
						Vector2 controlVector = Mathf.Approximately (normalizedVelocity.sqrMagnitude, 0.0f) ? new Vector2 () : new Vector2 (normalizedVelocity.x + 0.05f, normalizedVelocity.y + 0.05f);
						animator.SetFloat ("velocityY", controlVector.y, dampTime90, Time.deltaTime);
						animator.SetFloat ("velocityX", controlVector.x, dampTime90, Time.deltaTime);
			
				}

				
		}
}