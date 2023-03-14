using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAnimCtrl : MonoBehaviour
{
    private bool isAnimStarted = false;
    
    public void SetAbimDisappear()
    {
        if (!isAnimStarted){
            GetComponent<Animator>().SetTrigger("Dis");
            isAnimStarted = true;
        }
        else
        {
            isAnimStarted = false;
            GetComponent<Animator>().SetTrigger("Awake");
        }
        
    }

    public void Disappear()
    {
        isAnimStarted = false;
        //GetComponent<Animator>().SetBool("Dis", false);
        gameObject.SetActive(false);
    }
}
