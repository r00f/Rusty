using System.Linq;
using Assets.Scripts;
using UnityEngine;
using System.Collections.Generic;

public class AbsorbingWeapon : Weapon {


    // Use this for initialization
    public new void Start() {
        base.Start();
      

    }

    public void absorb(Weapon other) {
        foreach (KeyValuePair<string, Stat> entry in other.Stats.Where(entry => stats.ContainsKey(entry.Key))) {
            stats[entry.Key].Current += entry.Value.AbsorbingValue;
        }
    }
}
