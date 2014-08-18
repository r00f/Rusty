using UnityEngine;
using System.Collections;

public class layerSwapTrigger : MonoBehaviour {
	
	public float zPos;

	void Update()
	{
		zPos = transform.position.z;

	}

	void OnTriggerStay2D(Collider2D other) 
	{

		if (zPos == 0F)
		{
			transform.Translate (0, 0, 2);
		}
	}


	void OnTriggerExit2D(Collider2D other) {

		if (zPos == 2F) 
		{
			transform.Translate (0, 0, -2);
		}

	}


}