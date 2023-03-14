using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UnitMovement : MonoBehaviour
{
    [SerializeField] private UnitAnimatorController animatorController;
    [SerializeField] private GameObject bd;
    [SerializeField] private float speed = 4F;
    [SerializeField] private LayerMask leftBaseMask;
    [SerializeField] private LayerMask leftMask;

    private bool canGo = true;

    private void Awake()
    {
        animatorController.PlayRunAnimation();
    }
    void Update()
    {
       
       if(canGo)
           Move();
    }

    public void StartWalking(){
        canGo = true;
        animatorController.PlayRunAnimation();
    }
    public void StopWalking(){
        canGo = false;
        animatorController.PlayIdleAnimation();
    }
    public void ChangeDirection(bool dir)
    {
        if (dir == false)
        {
            speed = -speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            GetComponentInChildren<UnitStopControlle>().gameObject.layer = 12;//movestopRight
            try
            {
                GetComponentInChildren<UnitAttack>().mask = leftMask;
                GetComponentInChildren<UnitAttack>().baseMask = leftBaseMask;
            }
            catch
            {
                GetComponentInChildren<UnitShoot>().mask = leftMask;
                GetComponentInChildren<UnitShoot>().baseMask = leftBaseMask;
            }
            
            bd.layer = 8;

            /*GetComponentInChildren<SpriteRenderer>().flipX = true;
            GetComponentInChildren<UnitStopControlle>().leftWalking();*/
        }
    }
    private void Move()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime,  transform.position.y , transform.position.z) ;
    }

}
