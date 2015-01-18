using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour
{
		private GameController gameController;
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

		void OnTriggerEnter2D (Collider2D other)
		{
		
		Destroy (this.gameObject);
		gameController.AddCog (CogValue);
		}


}
