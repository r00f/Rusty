using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public Text cogAmountText;
	private int cogAmount;

	// Use this for initialization
	void Start () {
		cogAmount = 0;
		UpdateScore();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void UpdateScore() {
		cogAmountText.text = "" + cogAmount;
	}

	public void AddCog(int newCogValue) {
		cogAmount += newCogValue;
		UpdateScore ();
	}
}
