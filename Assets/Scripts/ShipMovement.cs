using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
    Rigidbody2D body;
    public float velocity;
	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * velocity, Input.GetAxisRaw("Vertical") * velocity);
	}
}
