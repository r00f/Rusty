using UnityEngine;
using System.Collections.Generic;

public class StatsView : MonoBehaviour {

    private GameObject _weapon;
    private Transform _myTransform;

    public Vector2 BasePosition;
    private Vector2 Position;

    public int height = 30;
    public int widthName = 150;
    public int widthNumber = 70;

    public string Title = "Stats";

    public GUIStyle labelstyleGuiStyle;
    public GUIStyle boxGuiStyle;

    public GameObject Weapon {
        get { return _weapon; }
        set {
            _weapon = value;
            WeaponSkript = value.GetComponent<Weapon>();
            _myTransform = value.transform;

        }
    }

    public Weapon WeaponSkript { get; set; }


    private void showStat(KeyValuePair<string, Stat> stat) {
        GUI.Label(new Rect(Position.x + 10, Position.y, widthName, height), stat.Key);
        GUI.Label(new Rect(Position.x + widthName, Position.y, widthNumber, height), stat.Value.ToString());
        Position.y += height;
    }

    void OnGUI() {
        if (WeaponSkript == null) {
            return;
        }
        if (_myTransform != null) {
            var point = Camera.main.WorldToScreenPoint(_myTransform.position);
            Position.y = Screen.height - (int) point.y;
            Position.x = (int) point.x;
        }
        else {
            Position = BasePosition;
        }
        int count = WeaponSkript.Stats != null ? WeaponSkript.Stats.Count : 0;
        GUI.Box(new Rect(Position.x, Position.y, widthName + widthNumber, count * height + 20), Title);
        Position.y += 20;
        if (WeaponSkript.Stats == null) return;
        foreach (KeyValuePair<string, Stat> stat in WeaponSkript.Stats) {
            showStat(stat);
        }
    }
}
