using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {
    public GameObject BulletPrefab;
    public float FireRate, BulletVelocity, StartDelay;
    public int EventIndexStart, EventIndexEnd;
    public bool CanShoot;
	// Use this for initialization
	void Start () {
        EventsTimeline.Events[EventIndexStart].OnStart += StartShoot;
        EventsTimeline.Events[EventIndexEnd].OnEnd += StopShoot;
    }

    void StartShoot()
    {
        CanShoot = true;
        StartCoroutine(Shoot());
    }

    void StopShoot()
    {
        CanShoot = false;
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(StartDelay);
        while (CanShoot)
        {
            GameObject NewBullet = BulletPrefab.Spawn(transform.position, Quaternion.identity);//Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
            NewBullet.GetComponent<Rigidbody2D>().velocity = transform.up * BulletVelocity;
            yield return new WaitForSeconds(FireRate);
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
