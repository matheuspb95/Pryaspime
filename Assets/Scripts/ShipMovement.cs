using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour {
	public float Velocity;

	Rigidbody2D body;
	SimpleFrameBasedAnimator anim;
	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody2D> ();
		anim = GetComponent<SimpleFrameBasedAnimator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float velx = Input.GetAxis ("Horizontal") * Velocity;
		float vely = Input.GetAxis ("Vertical")  * Velocity;

		body.velocity = new Vector2 (velx, vely);

		if (velx < -0.1f) {
			anim.CallAnimation ("MoveLeft");
		} else if (velx > 0.1f) {
			anim.CallAnimation ("MoveRight");
		} else {
			anim.CallAnimation ("Stop");
		}
	}
}
