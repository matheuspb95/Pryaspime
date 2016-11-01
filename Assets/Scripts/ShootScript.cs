using UnityEngine;
using System.Collections;

public class ShootScript : MonoBehaviour {
    public GameObject BulletPrefab;
    public float FireRate, BulletVelocity;
    public bool CanShoot;
	// Use this for initialization
	void Start () {
        StartCoroutine(Shoot());
	}

    IEnumerator Shoot()
    {
        while (CanShoot)
        {
            yield return new WaitForSeconds(FireRate);
            GameObject NewBullet = BulletPrefab.Spawn(transform.position, Quaternion.identity);//Instantiate(BulletPrefab, transform.position, Quaternion.identity) as GameObject;
            NewBullet.GetComponent<Rigidbody2D>().velocity = transform.up * BulletVelocity;
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
