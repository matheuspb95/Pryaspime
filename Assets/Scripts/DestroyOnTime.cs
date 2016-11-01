using UnityEngine;
using System.Collections;

public class DestroyOnTime : MonoBehaviour {
    public float time;
	// Use this for initialization
	void Start () {
        Invoke("RecycleTime", time);
	}
	
    void RecycleTime()
    {
        gameObject.Recycle();
    }

	// Update is called once per frame
	void Update () {
	
	}
}
