using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionLimits : MonoBehaviour {
	public Vector2 MaxLimits, MinLimits;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x > MaxLimits.x){
			transform.position = new Vector3(MaxLimits.x, transform.position.y, transform.position.z);
		}

		if(transform.position.x < MinLimits.x){
			transform.position = new Vector3(MinLimits.x, transform.position.y, transform.position.z);
		}

		if(transform.position.y > MaxLimits.y){
			transform.position = new Vector3(transform.position.x, MaxLimits.y, transform.position.z);
		}

		if(transform.position.y < MinLimits.y){
			transform.position = new Vector3(transform.position.x, MinLimits.y, transform.position.z);
		}
	}
}
