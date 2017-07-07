using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtension {

	public static Animator GetAnim(this MonoBehaviour GO){
		return GO.GetComponent<Animator> ();
	}


}
