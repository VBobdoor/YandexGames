using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class UnitAttack : MonoBehaviour
{
    [SerializeField] private UnitAnimatorController animatorController;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 1;
    [SerializeField] private int damage = 20;
    public LayerMask mask;
    public LayerMask baseMask;
    private int countMask;
    private int countMaskBase;
    private int triggeredObjects = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (mask.value == 256)
        {
            countMask = 8;
            countMaskBase = 10;
        }
        else
        {
            countMask = 7;
            countMaskBase = 9;
        }

        if (collision.gameObject.layer == countMask || collision.gameObject.layer == countMaskBase)
        {
            triggeredObjects++;
            animatorController.PlayAttackAnimation();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == countMask || collision.gameObject.layer == countMaskBase)
        {
            triggeredObjects--;
            if (triggeredObjects <= 0)
                animatorController.StopAttackAnimation();
        }

    }
    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, mask);
        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponentInParent<Health>().ChangeHealth(-damage);
            }
            catch { }
        }

        hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, baseMask);
        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponentInParent<Health>().ChangeHealth(-damage);
            }
            catch { }
        }

    }
}
