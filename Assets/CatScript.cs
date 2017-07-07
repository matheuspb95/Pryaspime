using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatScript : MonoBehaviour {
	Animator PatternController;
	public List<ShooterScript> Shooters = new List<ShooterScript>();
	// Use this for initialization
	void Start () {
		PatternController = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			PatternController.SetInteger("StateId", 1);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			PatternController.SetInteger("StateId", 2);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			PatternController.SetInteger("StateId", 3);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4)){
			PatternController.SetInteger("StateId", 4);
		}
	}

	public void AddShoot(int Index, int NumberOfShoots,float TimeBetweenShoots,int StartAngle,int AngleVariation, float EventDelay){
		Shooters[Index].AddShootEvent(NumberOfShoots, TimeBetweenShoots, StartAngle, AngleVariation, EventDelay);
	}

	public void StartShooting(int Index){
		StartCoroutine(Shooters[Index].StartEvents());
	}

}

