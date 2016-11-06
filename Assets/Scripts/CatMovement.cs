using UnityEngine;
using System.Collections;
using DG.Tweening;
public class CatMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.DOMoveX(2, 1).SetLoops(-1, LoopType.Yoyo).SetRelative().SetEase(Ease.InOutSine);
        transform.DOMoveY(0.5f, 0.7f).SetLoops(-1, LoopType.Yoyo).SetRelative().SetEase(Ease.InOutSine);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
