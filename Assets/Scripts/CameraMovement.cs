using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private double leftCap = - 0.78;
    [SerializeField] private double rightCap = 36.8;
    [SerializeField] private float animSpeed = 0.01f;
    private bool inUpgradeMode = false;
    private bool transitionStated = false;
    private Vector3 target1;
    private Vector3 target2;


    private void Awake()
    {
        target1 = new Vector3(-19.35f, -1.85f, transform.position.z);
        target2 = new Vector3(-15.35f, -4.6f, transform.position.z);
    }

    void LateUpdate()
    {

        if(transitionStated && inUpgradeMode) {
            transform.position = Vector3.MoveTowards(transform.position, target2, animSpeed * Time.deltaTime);
            if(Camera.main.orthographicSize < 8)
                Camera.main.orthographicSize += Time.deltaTime * 2.2f;
            else
                Camera.main.orthographicSize = 8;

            if (Camera.main.orthographicSize == 8 && transform.position.x >= target2.x - 0.1)
            {
                Camera.main.orthographicSize = 8;
                transform.position = target2;
                transitionStated = false;
            }
        }
            
        else if (transitionStated && !inUpgradeMode && transform.position != target1){
            transform.position = Vector3.MoveTowards(transform.position, target1, animSpeed * Time.deltaTime);
            if (Camera.main.orthographicSize > 6)
                Camera.main.orthographicSize -= Time.deltaTime * 2.2f;
            else
                Camera.main.orthographicSize = 6;

            
            if (Camera.main.orthographicSize == 6 && transform.position.x <= target1.x + 0.1)
            {
                Camera.main.orthographicSize = 6;
                transform.position = target1;
                transitionStated = false;
            }
                
        }
        else if (!inUpgradeMode)
        {
            //Debug.Log(Input.mousePosition.x);
            if (Input.mousePosition.x < Screen.width / 23 && gameObject.transform.position.x > leftCap && Input.mousePosition.y < Screen.height * 4.9 / 5)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else if (Input.mousePosition.x > Screen.width * 4.9 / 5 && gameObject.transform.position.x < rightCap && Input.mousePosition.y < Screen.height * 4.9 / 5)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + speed * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }
        

    }

    public void GotoUpgrades()
    {
        transitionStated = true;
        inUpgradeMode = !inUpgradeMode;
    }
}
