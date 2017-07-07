using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFrameBasedAnimator : MonoBehaviour {
	SpriteRenderer Sprite;

	public List<SimpleAnimation> Animations; 

	private Dictionary<string, SimpleAnimation> AnimDic  = new Dictionary<string, SimpleAnimation> ();
	// Use this for initialization
	void Start () {		
		Sprite = GetComponent<SpriteRenderer> ();
		foreach (SimpleAnimation sa in Animations) {
			AnimDic.Add (sa.Name, sa);
		}
	}

	public void CallAnimation(string name){
		if (!AnimDic [name].IsPlaying) {
			StartCoroutine (PlayAnim (AnimDic [name]));
		}
	}

	IEnumerator PlayAnim(SimpleAnimation Anim){
		List<Sprite> Frames = Anim.Frames;
		float fps = Anim.fps;
		int ActualSprite = 0;
		Anim.IsPlaying = true;
		while (ActualSprite < Frames.Count) {
			Sprite.sprite = Frames [ActualSprite];
			ActualSprite++;
			yield return new WaitForSeconds (1 / fps);
		}
		Anim.IsPlaying = false;
		StopAllCoroutines ();
	}
}

[Serializable]
public struct SimpleAnimation{
	public string Name;
	public List<Sprite> Frames;
	public bool IsPlaying;
	public float fps;
}
