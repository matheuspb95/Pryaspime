using UnityEngine;
using System.Collections;

public class Spin : MonoBehaviour {
    public float rotationY, rotationZ;
    float valueZ, valueY;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        valueY = (transform.eulerAngles.y + (Time.deltaTime * rotationY)) % 180;
        valueZ = (transform.eulerAngles.z + (Time.deltaTime * rotationZ)) % 180;

        transform.eulerAngles = new Vector3(0, valueY, valueZ);

	}
}
