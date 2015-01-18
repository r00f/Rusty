using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DoorController : MonoBehaviour
{
		private List<Animator> all_animators;
		private DoorTrigger trigger;
		private BoxCollider2D collision;
		public bool opening;
		public bool closing;
		public bool broken;
		public bool open;
		private bool isTriggered;
		static int openState = Animator.StringToHash ("Base Layer.Open");
		private AnimatorStateInfo currentState;

		// Use this for initialization
		void Start ()
		{
				
				Animator[] animators = this.GetComponentsInChildren<Animator> ();
				trigger = this.GetComponentInChildren<DoorTrigger> ();
				broken = false;
				all_animators = new List<Animator> (animators.Length);
				collision = GetComponentInChildren<BoxCollider2D> ();
				



				foreach (Animator a in animators) {
						all_animators.Add (a);
				}

		}
	
		// Update is called once per frame
		void Update ()
		{		

				
				isTriggered = trigger.triggered;

				if (opening) {
						closing = false;
						broken = false;
				} else if (closing) {
						opening = false;
						broken = false;
				}
				if (open) {
						Destroy (this.collision);
				}


				if (isTriggered) {
						opening = true;
				}


				foreach (var animator in all_animators) {
						currentState = animator.GetCurrentAnimatorStateInfo (0);

						if (currentState.nameHash == openState) {
								open = true;
						}
						animator.SetBool ("Opening", opening);
						animator.SetBool ("Closing", closing);
						animator.SetBool ("Broken", broken);
						animator.SetBool ("Open", open);

				}
		}


}
