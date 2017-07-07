using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CatState : StateMachineBehaviour {
	public List<TweenProps> tweens = new List<TweenProps>();
	List<Tweener> tweenCreated = new List<Tweener>();
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	 Transform transform;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		transform = animator.transform;
		foreach(TweenProps t in tweens){
			StartTween(t);
		}
	}

	

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		foreach(Tweener t in tweenCreated){
			Debug.Log(t);
			t.Pause();
			t.Kill();
		}
	}

	void StartTween(TweenProps tween){
		TweenParams TParams = new TweenParams().SetLoops(-1, tween.loopType).SetEase(tween.easeType).SetRelative(true).SetAutoKill(false);
		switch (tween.TweenType){
			case TweenOpts.PositionX:
				transform.DOMoveX(tween.initialValue, 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DOMoveX(tween.target, tween.duration).SetAs(TParams));
				});
			break;
			case TweenOpts.PositionY:
				transform.DOMoveY(tween.initialValue, 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DOMoveY(tween.target, tween.duration).SetAs(TParams));
				});
			break;
			case TweenOpts.PositionZ:
				transform.DOMoveZ(tween.initialValue, 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DOMoveZ(tween.target, tween.duration).SetAs(TParams));
				});
			break;
			case TweenOpts.RotationX:
				transform.DORotate(new Vector3(tween.initialValue, transform.eulerAngles.y, transform.eulerAngles.z), 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DORotate(new Vector3(tween.target, transform.eulerAngles.y, transform.eulerAngles.z) , tween.duration, RotateMode.FastBeyond360).SetAs(TParams));
				});
			break;
			case TweenOpts.RotationY:
				transform.DORotate(new Vector3(transform.eulerAngles.x ,tween.initialValue, transform.eulerAngles.z), 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DORotate(new Vector3(transform.eulerAngles.x, tween.target, transform.eulerAngles.z) , tween.duration, RotateMode.FastBeyond360).SetAs(TParams));
				});
			break;
			case TweenOpts.RotationZ:
				transform.DORotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, tween.initialValue), 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DORotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, tween.target) , tween.duration, RotateMode.FastBeyond360).SetAs(TParams));
				});
			break;
			case TweenOpts.ScaleX:
				transform.DOScaleX(tween.initialValue, 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DOScaleX(tween.target, tween.duration).SetAs(TParams));
				});
			break;
			case TweenOpts.ScaleY:
				transform.DOScaleY(tween.initialValue, 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DOScaleY(tween.target, tween.duration).SetAs(TParams));
				});
			break;
			case TweenOpts.ScaleZ:
				transform.DOScaleZ(tween.initialValue, 0.5f).SetLoops(0, LoopType.Restart).SetEase(tween.easeType).SetRelative(false).SetAutoKill(true).OnComplete(() => {
					tweenCreated.Add(transform.DOScaleZ(tween.target, tween.duration).SetAs(TParams));
				});
			break;
			default: return;
		}
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}


public enum TweenOpts{
	PositionX,PositionY,PositionZ, RotationX, RotationY, RotationZ, ScaleX,ScaleY,ScaleZ
}

[System.Serializable]
public struct TweenProps{
	public TweenOpts TweenType;
	public float initialValue;
	public float target;
	public float duration;
	public Ease easeType;
	public LoopType loopType;
	public Tweener tweenRefereance;
}
