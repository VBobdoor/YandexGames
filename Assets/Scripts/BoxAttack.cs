using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BoxAttack : MonoBehaviour
{
    [SerializeField] private LayerMask mask;
    [SerializeField] private Transform target;
    private int damage = 5;
    private float speed = 0.3f;
    private float currentSpeed = 0;

    private void Update()
    {
        currentSpeed += Time.deltaTime;
        if(currentSpeed >= speed)
        {
            currentSpeed = 0;
            Attack();
        }
    }

    private void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(transform.position, new Vector3(target.localPosition.x*2, target.localPosition.y * 2,target.localPosition.z * 2) , 0, mask);
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, mask);
        foreach (Collider2D enemy in hitEnemies)
        {
            try
            {
                enemy.GetComponentInParent<Health>().ChangeHealth(-damage);
            }
            catch { }
        }

    }

    public void setStats(int damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
    }

    void OnDrawGizmosSelected()
    {
        if (target != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;

            Gizmos.DrawLine(transform.position,target.position);
        }
    }
}
