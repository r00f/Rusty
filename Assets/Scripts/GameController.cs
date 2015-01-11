using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Assets.Scripts;

public class GameController : MonoBehaviour {
    private List<SpriteRenderer> all_walls;
    public int bounds;
    private int cogAmount;
    public Text cogAmountText;
    public int sortingLayerID;
    public int sortingOrder;
    public Object walls;
    // Use this for initialization
    private void Start() {
        cogAmount = 0;
        UpdateScore();

        GameObject[] objects = GameObject.FindGameObjectsWithTag(Tags.Wall);
        all_walls = new List<SpriteRenderer>(objects.Length);
        foreach (GameObject o in objects) {
            all_walls.Add(o.GetComponent<SpriteRenderer>());
        }
    }

    // Update is called once per frame
    private void Update() {
    }

    private void LateUpdate() {
        foreach (var wall in all_walls) {
            wall.sortingOrder = (int) Camera.main.WorldToScreenPoint(wall.bounds.min).y*-1;
        }
    }

    private void UpdateScore() {
        cogAmountText.text = "" + cogAmount;
    }

    public void AddCog(int newCogValue) {
        cogAmount += newCogValue;
        UpdateScore();
    }
}