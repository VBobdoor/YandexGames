using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityEventAnimationHandler : MonoBehaviour
{
    [SerializeField] private UnitAttack unitAttack;
    [SerializeField] private UnitShoot unitShoot;
    [SerializeField] private TowerAttack towerAttack;
    public void AttackPerfomce()
    {
        if (unitAttack != null)
            unitAttack.Attack();
        else if(unitShoot != null)
            unitShoot.Attack();
        else
            towerAttack.Attack();
    }
    
}
