using System.Collections;
using UnityEngine;

public class AlphaFade : MonoBehaviour
{

        
        public float minimum = 0.3f;
        public float maximum = 1f;
        public float fadeOutSpeed = 7f;
        public float fadeInSpeed = 5f;
        private SpriteRenderer sprite;
        public float spriteAlpha;
        public bool behindwall;
        
        // Update is called once per frame
        
        void Start ()
        {
                sprite = this.GetComponent<SpriteRenderer> ();
            
        }
        
        void Update ()
        {

                spriteAlpha = sprite.color.a;

                if (behindwall == true) {
                        
                        sprite.color = new Color (1f, 1f, 1f, Mathf.SmoothStep (spriteAlpha, minimum, fadeOutSpeed * Time.deltaTime));
                } else {

                        sprite.color = new Color (1f, 1f, 1f, Mathf.SmoothStep (spriteAlpha, maximum, fadeInSpeed * Time.deltaTime));
                }
        }
        
        void OnTriggerEnter2D (Collider2D other)
        {

                behindwall = true;
            
        }
        
        void OnTriggerExit2D (Collider2D other)
        {


                behindwall = false;
    

        }
        
        
        
}
