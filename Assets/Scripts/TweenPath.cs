using UnityEngine;
using System.Collections;
using DG.Tweening;

public class TweenPath : MonoBehaviour {
    public Vector3[] pathPoints;
    public float duration, delay;
    public Ease easeType;
    public PathType pathType;
    public PathMode pathMode;
    public LoopType loopType;
    // Use this for initialization
    void Start ()
    {
        transform.DOPath(pathPoints, duration, pathType, pathMode).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
