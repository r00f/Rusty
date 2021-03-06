﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts;

public class GameController : MonoBehaviour
{

		//Lists
		private List<SpriteRenderer> all_walls;

		//pause, menu
		public bool paused;
		private GameObject Menu;

		//Cog Pickup
		private int cogAmount;
		public Text cogAmountText;

		//Sorting Order
		public int bounds;
		public int sortingLayerID;
		public int sortingOrder;

		// Use this for initialization
		private void Start ()
		{
				paused = false;
				Menu = GameObject.FindGameObjectWithTag ("Menu");
				Menu.SetActive (false);
				Time.timeScale = 1F;
				Screen.showCursor = true;

				cogAmount = 0;
				UpdateScore ();

				GameObject[] walls = GameObject.FindGameObjectsWithTag (Tags.Wall);
				all_walls = new List<SpriteRenderer> (walls.Length);
				foreach (GameObject w in walls) {
						all_walls.Add (w.GetComponent<SpriteRenderer> ());
				}

		}

		void Update ()
		{
		
				if (Input.GetButtonDown ("Cancel")) {
						if (Time.timeScale == 1F) {
				
								Time.timeScale = 0F;
								paused = true;
				Screen.showCursor = true;
				Menu.SetActive (true);
						} else if (Time.timeScale == 0F) {
		
								Time.timeScale = 1F;
								paused = false;
				Screen.showCursor = false;
				Menu.SetActive (false);
						}
			
				}


		}

		private void LateUpdate ()
		{


				foreach (var wall in all_walls) {


						if (wall != null) {
								wall.sortingOrder = (int)Camera.main.WorldToScreenPoint (wall.bounds.min).y * -1;


						}
				}

		}

		private void UpdateScore ()
		{		
				cogAmountText.text = "" + cogAmount;
		}

		public void AddCog (int newCogValue)
		{
				cogAmount += newCogValue;
				UpdateScore ();
		}
}