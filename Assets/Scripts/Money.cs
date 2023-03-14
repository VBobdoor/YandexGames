using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private int money = 50;
    [SerializeField] private int moneyGainPerTime;
    [SerializeField] private float timeForGain;
    private float currentTime;
    private bool isFirstTime = false;
    public static Money clsMoney;
    private void Awake()
    {

        clsMoney = this;
        GainMoney(0);
        currentTime = timeForGain;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        if (currentTime <= 0) {
            GainMoney(moneyGainPerTime);
            currentTime = timeForGain;
        }
            
    }
    
    public void GainMoney(int val)
    {
        if (!isFirstTime && val != 0) {
            isFirstTime = true;
            EnemySpawner.enemySpawner.startWaves();
        }
            
        money += val;
        text.text = "x " + money.ToString();
    }
    
    public int GetMoney()
    {
        return money;
    }

    public void MoneyGainPerTimeChange(int value)
    {
        moneyGainPerTime = value;
    }
}
