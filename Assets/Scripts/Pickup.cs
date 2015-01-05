using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
		private GameController gameController;
		private bool trigger;
		private int CogValue = 1;

		// Use this for initialization
		void Start ()
		{
				GameObject gameControllerObject = GameObject.FindWithTag ("GameController");

				if (gameControllerObject != null) {
						gameController = gameControllerObject.GetComponent <GameController> ();
				}
				if (gameController == null) {
						Debug.Log ("Cannot find 'GameController' script");
				}

		}
	
		// Update is called once per frame
		void Update ()
		{
				if (trigger == true) {
						
						Destroy (this.gameObject);
						
				}

		}

		void OnTriggerEnter2D (Collider2D other)
		{
		
				trigger = true;
				gameController.AddCog (CogValue);
		}


}
