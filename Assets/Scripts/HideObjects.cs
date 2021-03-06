﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HideObjects : MonoBehaviour {
	
	public Transform WatchTarget;
	public LayerMask OccluderMask;
	
	private List<Transform> _LastTransforms;
	
	void Start () {
		_LastTransforms = new List<Transform>();
	}
	
	void Update () {
		//reset and clear all the previous objects
		if(_LastTransforms.Count > 0){
			foreach(Transform t in _LastTransforms)
				t.GetComponent<SpriteRenderer>().enabled = true;
			_LastTransforms.Clear();
		}
		
		//Cast a ray from this object's transform the the watch target's transform.
		RaycastHit2D[] hits = Physics2D.RaycastAll(
			transform.position,
			WatchTarget.transform.position - transform.position,
			Vector3.Distance(WatchTarget.transform.position, transform.position),
			OccluderMask
			);
		
		//Loop through all overlapping objects and disable their mesh renderer
		if(hits.Length > 0){
			foreach(RaycastHit2D hit in hits){
				if(hit.collider.gameObject.transform != WatchTarget && hit.collider.transform.root != WatchTarget){
					hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
					_LastTransforms.Add(hit.collider.gameObject.transform);
				}
			}
		}
	}
}