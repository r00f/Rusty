using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

		public Text cogAmountText;
		private int cogAmount;
		public Object walls;
		public int sortingLayerID;
		public int sortingOrder;
		public int bounds;

		// Use this for initialization
		void Start ()
		{
				cogAmount = 0;
				UpdateScore ();

		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void LateUpdate ()
		{	

				GameObject[] walls;
				walls = GameObject.FindGameObjectsWithTag ("Wall");

				foreach (GameObject wall in walls) {
						SpriteRenderer wallSprite;
						wallSprite = wall.GetComponent<SpriteRenderer> ();
						wallSprite.sortingOrder = (int)Camera.main.WorldToScreenPoint (wallSprite.bounds.min).y * -1;
			
				}



		}

		void UpdateScore ()
		{
				cogAmountText.text = "" + cogAmount;
		}

		public void AddCog (int newCogValue)
		{
				cogAmount += newCogValue;
				UpdateScore ();
		}
}
