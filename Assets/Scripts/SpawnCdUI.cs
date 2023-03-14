using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCdUI : MonoBehaviour
{
    public static SpawnCdUI spawnCdUI;
    [SerializeField] private Image[] images;
    [SerializeField] private HeadAppearUI[] headAppearUI;
    private bool isStatedSpawn = false;
    private float coolDown;
    private float currentCoolDown;
    private int number;

    private void Awake()
    {
        spawnCdUI = this;
    }
    private void FixedUpdate()
    {
        if (isStatedSpawn)
        {
            currentCoolDown -= Time.fixedDeltaTime;

            images[number].fillAmount = currentCoolDown / coolDown;
            if (currentCoolDown <= 0)
            {
                images[number].fillAmount = 0;
                images[number].gameObject.SetActive(false);
                isStatedSpawn = false;
                Spawner.spawner.Spawn();
            }
        }


    }

    private void UpdateUI(int[] buf)
    {
        for (int i = 1; i < buf.Length; i++)
        {
            if (buf[i] != -1){
                headAppearUI[i].ShowHead(buf[i]);
            }
            else{
                headAppearUI[i].HideHead();
            }
        }
  
    }
    
    public void StartSpawning(int[] buf, float cd){
        if (!isStatedSpawn && buf[0] != -1)
        {
            number = buf[0];
            images[number].gameObject.SetActive(true);
            isStatedSpawn = true;
            currentCoolDown = cd;
            coolDown = cd;
            
        }
        UpdateUI(buf);
    }

    
}
