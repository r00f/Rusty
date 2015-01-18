using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour
{
		public bool triggered;
	
		void OnTriggerStay2D (Collider2D trigger)
		{
				var E = Input.GetKey ("e");
				if (E) {
						triggered = true;
				}
		}

		void OnTriggerExit2D (Collider2D trigger)
		{
				triggered = false;
		}

}
