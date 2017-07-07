using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShooterState : StateMachineBehaviour {
	public List<Shooter> Shooters = new List<Shooter>();
	CatScript Cat;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Cat = animator.GetComponent<CatScript>();
		StartPattern();
	}

	void StartPattern(){
		int i = 0;
		foreach(Shooter shooter in Shooters){
			foreach(ShootEvent patt in shooter.Patterns){
				Cat.AddShoot(i, patt.NumberOfShoots, patt.TimeBetweenShoots, patt.StartAngle, patt.AngleVariation, patt.EventDelay);
			}
			Cat.StartShooting(i);
			i++;
		}
		
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		Cat.StopAllCoroutines();
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

[System.Serializable]
public struct ShootEvent{
	public int NumberOfShoots;
	public float TimeBetweenShoots;
	public float EventDelay;
	public int StartAngle;
	public int AngleVariation;
}

[CustomPropertyDrawer(typeof(ShootEvent))]
public class PatternPropertyDrawer : PropertyDrawer  {

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {

        Rect amountRect1 = new Rect(position.x, position.y, 30, position.height);
        Rect unitRect1 = new Rect(position.x+35, position.y, 50, position.height);
        Rect nameRect1 = new Rect(position.x+90, position.y, position.width-90, position.height);
		EditorGUI.TextField(amountRect1, "asas");
		EditorGUI.BeginProperty(position, label, property);
		position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
		int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        Rect amountRect = new Rect(position.x, position.y, 30, position.height);
        Rect unitRect = new Rect(position.x+35, position.y, 50, position.height);
        Rect nameRect = new Rect(position.x+90, position.y, position.width-90, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(amountRect, property.FindPropertyRelative ("NumberOfShoots"), GUIContent.none);
        EditorGUI.PropertyField(unitRect, property.FindPropertyRelative ("TimeBetweenShoots"), GUIContent.none);
        EditorGUI.PropertyField(nameRect, property.FindPropertyRelative ("EventDelay"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
	}
}


[System.Serializable]
public struct Shooter{
	public List<ShootEvent> Patterns;
}



