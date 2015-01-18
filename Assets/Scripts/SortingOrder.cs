using UnityEngine;
using System.Collections;

public class SortingOrder : MonoBehaviour
{

		public int sortingLayerID;
		public int sortingOrder;
		public int bounds;
		private int scaledOffset;
		private int scaledOffsetA;
		private int offset;
		private SpriteRenderer spriteRenderer;
		private int worldToScreen;
		public bool playerBehindWall;


		// Use this for initialization
		void Start ()
		{		

				scaledOffset = Screen.height / 7;
				scaledOffsetA = scaledOffset / 3;
				spriteRenderer = this.GetComponent<SpriteRenderer> ();
		}

		// Update is called once per frame
		void Update ()
		{
				var space = Input.GetKey ("space");

				if (space == true && playerBehindWall == false) {
						offset = scaledOffset;
				} else if (space == true && playerBehindWall == true) {
						offset = 0;
				} else {
						offset = scaledOffsetA;
				}
		}

		void LateUpdate ()
		{


				worldToScreen = (int)Camera.main.WorldToScreenPoint (spriteRenderer.bounds.min).y * -1;
				spriteRenderer.sortingOrder = worldToScreen + offset;

		}
    

}
