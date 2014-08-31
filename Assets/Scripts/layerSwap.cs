using UnityEngine;
using System.Collections;

public class layerSwap : MonoBehaviour {

	public int sortingLayerID;
	public int sortingOrder;

	void OnTriggerEnter (Collider layerSwapTrigger) {
		GameObject.Find("wall_part").renderer.sortingLayerID = sortingLayerID;
	
	}

}