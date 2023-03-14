using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonArrow : MonoBehaviour
{
    [SerializeField] public float speed = 10f;
    [SerializeField] public Transform target;
    [SerializeField] private int damage;
    public LayerMask mask;
    public LayerMask baseMask;
    private int countMask;
    private int countMaskBase;
    private bool targetSetted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(targetSetted)
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
            try
            {
                if (collision.gameObject.layer == countMask || collision.gameObject.layer == countMaskBase)
                {
                    collision.GetComponentInParent<Health>().ChangeHealth(-damage);
                    Destroy(gameObject);
                }
            }
            catch { }
        }
        

    }

    public void GetDirection(int dir)
    {
        if (dir == 1){
            mask.value = 256;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else {
            mask.value = 128;
            transform.rotation = Quaternion.Euler(0,180,0);
        }
            

        GetComponent<Rigidbody2D>().AddForce(new Vector2(speed * dir, 0.2f),ForceMode2D.Impulse);
        targetSetted = true;
    }
    private void Update()
    {
        /*transform.rotation = Quaternion.Euler(0, transform.rotation.y + Time.deltaTime * 10, 0);

        try
        {
            if (target != null && targetSetted == false)
            {
                targetSetted = true;
                if (target.position.x > transform.position.x)
                {
                    transform.rotation = Quaternion.Euler(0, -30, 0);
                }
                else
                {
                    transform.rotation = Quaternion.Euler(0, 210, 0);
                }
            }

            if (transform.position.y < -5)
            {
                Destroy(gameObject);
            }

            //transform.position = new Vector2(Vector2.Lerp(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), speed).x, transform.position.y);



        }
        catch
        {
            Destroy(gameObject);
        }*/
    }
}
