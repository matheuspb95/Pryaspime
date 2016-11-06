using UnityEngine;
using System.Collections;

public class TransformLimits : MonoBehaviour {
    public Bounds boundaries;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(transform.position.x < boundaries.min.x)
        {
            transform.position = new Vector3(boundaries.min.x, transform.position.y);
        }
        if (transform.position.x > boundaries.max.x)
        {
            transform.position = new Vector3(boundaries.max.x, transform.position.y);
        }
        if (transform.position.y < boundaries.min.y)
        {
            transform.position = new Vector3(transform.position.x, boundaries.min.y);
        }
        if (transform.position.y > boundaries.max.y)
        {
            transform.position = new Vector3(transform.position.x, boundaries.max.y);
        }
    }
}
