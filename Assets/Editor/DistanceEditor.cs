using UnityEditor;
using System.Collections;
using UnityEngine;

[CustomEditor(typeof(StatsVisibleDistance))]
public class DistanceEditor : Editor {
    public int circleSize = 5;

    // Use this for initialization
    void Start() {
        
    }

    public void OnSceneGUI() {
        Handles.color = new Color(1,1,1,0.2f);//distance.transform.position
        StatsVisibleDistance distance = (StatsVisibleDistance)target;
        Transform transform = distance.gameObject.transform;
        Handles.DrawSolidArc(transform.position, Vector3.forward, Vector3.right, 360, distance.Radius);
        Handles.color = Color.white;

        distance.Radius = Handles.ScaleValueHandle(distance.Radius,
            transform.position + Vector3.right*distance.Radius,
            Quaternion.LookRotation(Vector3.right),
            1,
            Handles.ConeCap,
            1);
        if (GUI.changed)
            EditorUtility.SetDirty(target);
    }


    // Update is called once per frame
    void Update() {

    }
}
