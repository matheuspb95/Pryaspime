using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour {
	public Material material;
	public float hue;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hue = Time.timeSinceLevelLoad - Mathf.FloorToInt (Time.timeSinceLevelLoad);
		material.SetFloat ("_ColorFactorChanger", hue);
	}
}
