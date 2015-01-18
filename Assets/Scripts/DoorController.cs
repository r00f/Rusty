using UnityEngine;
using System.Collections;
using System.Collections.Generic;

internal enum DoorState {
    Opening,
    Closing,
    Open,
    Broken,
    Closed
}

public class DoorController : MonoBehaviour {
    private List<Animator> all_animators;
    private DoorTrigger trigger;
    private BoxCollider2D collision;
    private bool isTriggered;
    private static int openState = Animator.StringToHash("Base Layer.Open");
    private AnimatorStateInfo currentState;

    private DoorState currentDoorState = DoorState.Closed;


    // Use this for initialization
    private void Start() {
        Animator[] animators = this.GetComponentsInChildren<Animator>();
        trigger = this.GetComponentInChildren<DoorTrigger>();
        all_animators = new List<Animator>(animators.Length);
        collision = GetComponentInChildren<BoxCollider2D>();

        foreach (Animator a in animators) {
            all_animators.Add(a);
        }
    }

    // Update is called once per frame
    private void Update() {
        isTriggered = trigger.triggered;

        if (currentDoorState == DoorState.Open) {
            Destroy(this.collision);
        }

        if (isTriggered) {
            currentDoorState = DoorState.Opening;
        }


        foreach (var animator in all_animators) {
            currentState = animator.GetCurrentAnimatorStateInfo(0);

            if (currentState.nameHash == openState) {
                currentDoorState = DoorState.Open;
            }
            animator.SetBool("Opening", currentDoorState == DoorState.Opening);
            animator.SetBool("Closing", currentDoorState == DoorState.Closing);
            animator.SetBool("Broken", currentDoorState == DoorState.Broken);
            animator.SetBool("Open", currentDoorState == DoorState.Open);
        }
    }
}