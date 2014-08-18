using Assets.Scripts;
using UnityEngine;
using System.Collections.Generic;

public class Weapon : MonoBehaviour {

    public Stat damage = new Stat(2);
    public Stat swingSpeed = new Stat(3);
    public Stat size = new Stat();

    public Stat magicAttack = new Stat(2);
    public Stat magicPenetration = new Stat(5);

    protected Dictionary<string, Stat> stats = new Dictionary<string, Stat>();

    protected StatsView view;

    public int Height = 18;
    public int WidthName = 150;
    public int WidthNumber = 70;

    public GUIStyle customGuiStyle;

    private bool collideOuter;

    private Transform player;

    private Transform myTransform;

    private StatsVisibleDistance distance;


    public Dictionary<string, Stat> Stats {
        get {
            return stats;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == Tags.Player) {
                other.gameObject.GetComponent<AbsorbingWeapon>().absorb(this);
                Destroy(gameObject); 
        }
    }


    public void Update() {
        if (distance != null) {
            view.enabled = Vector2.Distance(myTransform.position, player.position) < distance.Distance;
        }
    }


    // Use this for initialization
    public void Start() {
        stats.Add("Damage", damage);
        stats.Add("SwingSpeed", swingSpeed);
        stats.Add("Size", size);
        stats.Add("Magic Attack", magicAttack);
        stats.Add("Magic Penetration", magicPenetration);

        player = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        myTransform = transform;
        distance = gameObject.GetComponent<StatsVisibleDistance>();
        view = gameObject.GetComponent<StatsView>();
        if (view == null) {
            view = gameObject.AddComponent<StatsView>();
            view.enabled = false;
            view.Weapon = gameObject;
        } else {
            view.WeaponSkript = this;
        }
    }

}
