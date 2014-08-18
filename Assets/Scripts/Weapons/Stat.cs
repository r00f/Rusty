using UnityEngine;
using System.Collections;

[System.Serializable]
public class Stat : PropertyAttribute {

    public int Current = 1;
    public int Maximum = 250;
    public float AbsorptionRate = 0.1f;


    public Stat(int current = 1, int maximum = 250, float absorption = 0.1f) {
        this.Maximum = maximum;
        this.Current = current;
        this.AbsorptionRate = absorption;
    }

    public int AbsorbingValue {
        get { return (int) (Current*AbsorptionRate); }
    }

    public void Add(int value) {
        int newVal = Current + value;
        Current = newVal > Maximum ? Maximum : newVal;
    }

    void OnValidate() {
        Debug.Log("Validate");
        if (this.Current > this.Maximum) this.Current = this.Maximum;
    }




    override public string ToString() {
        return Current.ToString() + " / " + Maximum.ToString();
    }
}

