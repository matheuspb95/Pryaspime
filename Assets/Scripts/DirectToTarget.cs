﻿using UnityEngine;
using System.Collections;

public class DirectToTarget : MonoBehaviour {
    public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion rotation = Quaternion.LookRotation
             (transform.position - target.transform.position, transform.TransformDirection(Vector3.forward));
        transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
    }
}
