using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal enum SwitchState
{
		Opening,
		Closing,
		Open,
		Broken,
		Closed
}

public class SwitchController : MonoBehaviour
{
		private Animator animator;
		private DoorTrigger trigger;
		private BoxCollider2D collision;
		private bool isTriggered;
		private static int SwitchOpenState = Animator.StringToHash ("Switch.Open");
		private AnimatorStateInfo currentState;
		public bool switchOpen;
		private SwitchState currentSwitchState = SwitchState.Closed;
	
		// Use this for initialization
		private void Start ()
		{
				animator = this.GetComponent<Animator>();
				trigger = this.GetComponentInChildren<DoorTrigger> ();
		}
	
		// Update is called once per frame
		private void Update ()
		{
		
				isTriggered = trigger.triggered;
		
				if (isTriggered) {
						currentSwitchState = SwitchState.Opening;
				}
		
				if (currentSwitchState == SwitchState.Open) {
						switchOpen = true;
				} else {
					switchOpen = false;
				}

				currentState = animator.GetCurrentAnimatorStateInfo (0);

				if (currentState.nameHash == SwitchOpenState) {
						currentSwitchState = SwitchState.Open;
				}
		
				animator.SetBool ("Opening", currentSwitchState == SwitchState.Opening);
				animator.SetBool ("Closing", currentSwitchState == SwitchState.Closing);
				animator.SetBool ("Broken", currentSwitchState == SwitchState.Broken);
				animator.SetBool ("Open", currentSwitchState == SwitchState.Open);
		
		
		
		}
}