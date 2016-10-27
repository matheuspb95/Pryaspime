using UnityEngine;
using System.Collections;

public class CanonScript : MonoBehaviour {
    public float duration, fromAngle, toAngle;
	// Use this for initialization
	void Start () {
        StartCoroutine(ShootRotating());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator ShootRotating()
    {
        GetComponent<ShootScript>().CanShoot = true;
        transform.rotation = Quaternion.Euler(0, 0, fromAngle);
        float time = 0;
        while(time <= duration)
        {
            time += Time.deltaTime;
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, fromAngle), Quaternion.Euler(0, 0, toAngle), time / duration);
            yield return new WaitForEndOfFrame();
        }
        GetComponent<ShootScript>().CanShoot = false;
    }
}
