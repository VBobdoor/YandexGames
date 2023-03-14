using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStopControlle : MonoBehaviour
{
    [SerializeField] Transform leftPoint;

    private UnitMovement unitMovement;
    private int triggerEntCount = 0;

    private void Awake()
    {
        unitMovement = GetComponentInParent<UnitMovement>();

    }
   
    public void leftWalking()
    {
        transform.position = leftPoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEntCount++;
        unitMovement.StopWalking();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerEntCount--;
        if(triggerEntCount <= 0)
        {
            unitMovement.StartWalking();
            triggerEntCount = 0;
        }
            
    }
}
