using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesInCastle : MonoBehaviour
{
    private CameraMovement cameraMovement;
    [SerializeField] private GameObject[] tables;
    [SerializeField] private GameObject spawnUI;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        cameraMovement = Camera.main.GetComponent<CameraMovement>() ;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnMouseDown()
    {
        foreach(GameObject table in tables)
        {
            if(table.activeSelf == false)
                table.SetActive(true);
            else
                table.GetComponent<TableAnimCtrl>().SetAbimDisappear();   
        }
        if (spawnUI.activeSelf == false)
            spawnUI.SetActive(true);
        else
            spawnUI.GetComponent<TableAnimCtrl>().SetAbimDisappear();

        //spawnUI.SetActive(spriteRenderer.flipY);
        cameraMovement.GotoUpgrades();
        spriteRenderer.flipY = !spriteRenderer.flipY;
    }
}
