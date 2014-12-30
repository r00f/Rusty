using UnityEngine;
using System.Collections;

public class SortingOrder : MonoBehaviour
{

        public int sortingLayerID;
        public int sortingOrder;
        public int bounds;
        private SpriteRenderer spriteRenderer;

        // Use this for initialization
        void Start ()
        {
                spriteRenderer = this.GetComponent<SpriteRenderer> ();
        }

        // Update is called once per frame
        void Update ()
        {
    
        }

        void LateUpdate ()
        {


                spriteRenderer.sortingOrder = (int)Camera.main.WorldToScreenPoint (spriteRenderer.bounds.min).y * -1;
        }
    

}
