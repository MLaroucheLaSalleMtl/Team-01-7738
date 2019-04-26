using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKRightArm : MonoBehaviour
{
    public Animator anim;
    public float weightPosition = 0.8f;
    public float weightRotation = 0.8f;
    public float weightLook = 0.8f;
    public Transform myTarget;


    private void OnAnimatorIK()
    {
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weightPosition);
        anim.SetIKPosition(AvatarIKGoal.RightHand, myTarget.position);

        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, weightRotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, myTarget.rotation);

        anim.SetLookAtWeight(weightLook);
    }
}
