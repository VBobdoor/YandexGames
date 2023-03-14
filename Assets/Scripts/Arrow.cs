using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Arrow : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] public Transform target;
    [SerializeField] private int damage;
    public LayerMask mask;
    public LayerMask baseMask;
    private int countMask;
    private int countMaskBase;
    private bool targetSetted = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (mask.value == 256) {
            countMask = 8;
            countMaskBase = 10;
        }else{
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
    private void Awake()
    {
        //speed *= 0.002f;
        GetComponent<Rigidbody2D>().velocity =new Vector2(1, 10f);
    }
    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - Time.deltaTime * 50);

        try
        {
            if(target != null && targetSetted == false){
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
        
            if(transform.position.y < -5)
            {
                Destroy(gameObject);
            }
        
            transform.position = new Vector2(Vector2.Lerp(transform.position, new Vector3(target.position.x +0.2f, transform.position.y, transform.position.z), speed * Time.deltaTime).x, transform.position.y);


            
        }
        catch
        {
            Destroy(gameObject);
        }
    }
}
