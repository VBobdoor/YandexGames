using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;

public class UnitAnimatorController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    public void PlayAttackAnimation(){
        animator.SetBool("Attack", true);
    }
    public void StopAttackAnimation()
    {
        animator.SetBool("Attack", false);
    }

    public void PlayRunAnimation()
    {
        animator.SetBool("Run", true);
    }
    public void PlayIdleAnimation()
    {
        animator.SetBool("Run", false);
    }

}
