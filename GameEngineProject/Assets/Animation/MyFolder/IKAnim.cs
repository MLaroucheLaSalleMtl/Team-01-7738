
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKAnim : MonoBehaviour {

    [SerializeField] private Animator anim;
    [SerializeField] private float weightForPosition = 0.8f;
    [SerializeField] private float weightForRotation = 0.8f;
    [SerializeField] private float weightForLook = 0.8f;
    [SerializeField] private Transform rightArmTarget;

    [SerializeField] private float bodyWeight = 0.5f;
    [SerializeField] private float headWeight = 1f;
    [SerializeField] private float eyesWeight = 1f;
    [SerializeField] private float clampWeight = 0.5f;

    private void OnAnimatorIK()
    {
        // define a weight for IK
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, weightForPosition);

        //define a position for IK (keep a little bit of the original position)
        anim.SetIKPosition(AvatarIKGoal.LeftHand, rightArmTarget.position);

        //for the hand to be pointing and not asking for money
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, weightForRotation);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, rightArmTarget.rotation);

        anim.SetLookAtWeight(weightForLook, bodyWeight, headWeight, eyesWeight, clampWeight);
        anim.SetLookAtPosition(rightArmTarget.position);
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
