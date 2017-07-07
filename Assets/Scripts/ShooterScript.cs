using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour {
	public GameObject BulletPrefab;

	List<IEnumerator> Events = new List<IEnumerator>();
	void Start(){	
		
	}

	public void AddShootEvent(int NumberOfShoots,float TimeBetweenShoots,int StartAngle,int AngleVariation,float EventDelay){
		Events.Add(SequenceShoot(NumberOfShoots, TimeBetweenShoots, StartAngle, AngleVariation, EventDelay));
	}

	public void Shoot(int NumberOfShoots,float TimeBetweenShoots,int StartAngle,int AngleVariation){
		StartCoroutine(SequenceShoot(NumberOfShoots, TimeBetweenShoots, StartAngle, AngleVariation, 0));	
	}

	public IEnumerator StartEvents(){
		foreach(IEnumerator ienum in Events){			
			yield return StartCoroutine(ienum);
		}
	}

	public IEnumerator SequenceShoot(int NumberOfShoots, float TimeBetweenBullets, int StartAngle, int Anglevar,float EventDelay){
		yield return new WaitForSeconds(EventDelay);
		if(TimeBetweenBullets <= 0){
			for(int i = 0; i< NumberOfShoots; i++){
				transform.eulerAngles = new Vector3(0,0,StartAngle - Anglevar * i);		
				ShootUnity(transform.up, 4);
			}
			yield return null;	
		}else{
			for(int i = 0; i< NumberOfShoots; i++){
				yield return new WaitForSeconds(TimeBetweenBullets);	
				transform.eulerAngles = new Vector3(0,0,StartAngle - Anglevar * i);		
				ShootUnity(transform.up, 4);
			}
		}
	}

	void ShootUnity(Vector2 direction, float velocity){
		BulletPrefab.Spawn (transform.position).GetComponent<Rigidbody2D> ().velocity = direction * velocity;
	}
}
