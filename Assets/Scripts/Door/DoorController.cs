using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal enum DoorState
{
		Opening,
		Closing,
		Open,
		Broken,
		Closed
}

public class DoorController : MonoBehaviour
{
		private List<Animator> all_animators;
		private SwitchController switchController;
		private BoxCollider2D collision;
		private static int DoorOpenState = Animator.StringToHash ("Door.Open");
		private AnimatorStateInfo currentState;
		private DoorState currentDoorState = DoorState.Closed;
		public bool switchO;



		// Use this for initialization
		private void Start ()
		{
				Animator[] animators = this.GetComponentsInChildren<Animator> ();
				switchController = this.GetComponentInParent<SwitchController> ();
				all_animators = new List<Animator> (animators.Length);
				collision = GetComponentInChildren<BoxCollider2D> ();
				switchO = switchController.switchOpen;

				foreach (Animator a in animators) {
						all_animators.Add (a);
				}
		}

		// Update is called once per frame
		private void Update ()
		{

		switchO = switchController.switchOpen;
				if (currentDoorState == DoorState.Open) {
						Destroy (this.collision);
				}
	
		if (switchO && currentState.nameHash != DoorOpenState) {
				currentDoorState = DoorState.Opening;
			}



				
        
				foreach (var animator in all_animators) {

						currentState = animator.GetCurrentAnimatorStateInfo (0);

			if (currentState.nameHash == DoorOpenState) {
				currentDoorState = DoorState.Open;
			}

						animator.SetBool ("Opening", currentDoorState == DoorState.Opening);
						animator.SetBool ("Closing", currentDoorState == DoorState.Closing);
						animator.SetBool ("Broken", currentDoorState == DoorState.Broken);
						animator.SetBool ("Open", currentDoorState == DoorState.Open);

				}
		}
}