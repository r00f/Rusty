using UnityEngine;
using System.Collections;


public class SortingOrderScript : MonoBehaviour
{
	public const string TOP = "TopLayer";
	public const string BOTTOM = "BottomLayer";
	public int sortingOrder = 0;
	private SpriteRenderer sprite;
	public bool swapLayer;
	
	void Start()
	{
		sprite = GetComponent<SpriteRenderer> ();


		if (sprite) {
				sprite.sortingOrder = sortingOrder;
						sprite.sortingLayerName = BOTTOM;
		}
	
	}


	void Update()
	{
		
	/*	if (swapLayer = true)
		{
			sprite.sortingLayerName = BOTTOM;
		}
		else
		{
			sprite.sortingLayerName = TOP;
		}
		
		*/
	}


	
}