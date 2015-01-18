using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts;

public class GameController : MonoBehaviour
{

		//Lists
		private List<SpriteRenderer> all_walls;
//		private List<SpriteRenderer> all_collectables;
		private GameObject[] walls;
		private GameObject[] collectables;

		//Cog Pickup
		private int cogAmount;
		public Text cogAmountText;

		//Sorting Order
		public int bounds;
		public int sortingLayerID;
		public int sortingOrder;

		//Alpha Fade
		public float minimum = 0.3f;
		public float maximum = 1f;
		public float fadeOutSpeed = 7f;
		public float fadeInSpeed = 5f;
		public float wallAlpha;
		private AlphaFade wallTrigger;

		// Use this for initialization
		private void Start ()
		{
				cogAmount = 0;
				UpdateScore ();

				GameObject[] walls = GameObject.FindGameObjectsWithTag (Tags.Wall);
				all_walls = new List<SpriteRenderer> (walls.Length);
				foreach (GameObject w in walls) {
						all_walls.Add (w.GetComponent<SpriteRenderer> ());
				}

				/*	GameObject[] collectables = GameObject.FindGameObjectsWithTag (Tags.Collectable);
				all_collectables = new List<SpriteRenderer> (collectables.Length);
				foreach (GameObject c in collectables) {
						all_collectables.Add (c.GetComponent<SpriteRenderer> ());
				}*/



		}

		private void LateUpdate ()
		{

				foreach (var wall in all_walls) {


						if (wall != null) {
								wall.sortingOrder = (int)Camera.main.WorldToScreenPoint (wall.bounds.min).y * -1;


						}
				}

				/*foreach (var collectable in all_collectables) {
			
			
			
						collectable.sortingOrder = (int)Camera.main.WorldToScreenPoint (collectable.bounds.min).y * -1;
			
			
			
				}*/


		}

		private void UpdateScore ()
		{		
				//Debug.Log("hello" + Screen.height);
				cogAmountText.text = "" + cogAmount;
		}

		public void AddCog (int newCogValue)
		{
				cogAmount += newCogValue;
				UpdateScore ();
		}
}