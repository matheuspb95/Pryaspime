using UnityEngine;
using System.Collections;
using DG.Tweening;
public class TweenTransform : MonoBehaviour {
    public enum Axis
    {
        posx, posy, posz, rotx, roty, rotz, scalex, scaley, scalez, path
    }
    public Axis axis;
    public float toValue, duration,  delay;
    public Ease easeType;
    public LoopType loopType;
	// Use this for initialization
	void Start () {
        switch (axis)
        {
            case Axis.posx:
                transform.DOMoveX(toValue, duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;
            case Axis.posy:
                transform.DOMoveY(toValue, duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;
            case Axis.posz:
                transform.DOMoveZ(toValue, duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;
            case Axis.rotx:
                transform.DORotate(new Vector3(toValue, 0, 0), duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;
            case Axis.roty:
                transform.DORotate(new Vector3(0, toValue, 0), duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;
            case Axis.rotz:
                transform.DORotate(new Vector3(0, 0, toValue), duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;
            case Axis.scalex:
                transform.DOScaleX(toValue, duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;
            case Axis.scaley:
                transform.DOScaleY(toValue, duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;
            case Axis.scalez:
                transform.DOScaleZ(toValue, duration).SetLoops(-1, loopType).SetRelative().SetEase(easeType).SetDelay(delay);
                break;

        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
