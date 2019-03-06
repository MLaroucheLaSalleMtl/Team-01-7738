using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAim : MonoBehaviour
{

    private MikeControl mikeCode;
    private Animator anim;
    [SerializeField] private Transform target;
    [SerializeField] private Quaternion bodyRotation;
    private Transform chest;
    [SerializeField] private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mikeCode = GetComponent<MikeControl>();
        anim = GetComponent<Animator>();
        chest = anim.GetBoneTransform(HumanBodyBones.Spine);
    }

    //private void OnAnimatorIK()
    //{
    //    //if (Input.GetButton("Fire2"))
    //    //{
    //        anim.SetIKRotation(bodyRotation);
    //    //}
    //}

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetButton("Fire2"))
        {
            anim.SetBool("Aim", true);
            mikeCode.enabled = false;
            chest.LookAt(target.position);
            chest.rotation = chest.rotation * Quaternion.Euler(offset);
        }
        else
        {
            anim.SetBool("Aim", false);
            mikeCode.enabled = true;
        }
    }
}
