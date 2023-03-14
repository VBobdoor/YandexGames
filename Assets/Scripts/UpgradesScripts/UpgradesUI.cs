using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesUI : MonoBehaviour
{
    public static UpgradesUI upgradesUI;
    [SerializeField] private GameObject tower;
    private int towerLevel = 0;
    private int armyLevel = 0;
    private int digLevel = 0;
    private int towerCost = 50;
    private int armyCost = 50;
    private int digCost = 50;

    private void Awake()
    {
        upgradesUI = this;
    }

    public void TowerBtnClick()
    {
        if (Money.clsMoney.GetMoney() >= towerCost && towerLevel < 5)
        {
            Money.clsMoney.GainMoney(-towerCost);
            towerCost += 150;
            towerLevel++;
            TowerUpgrade.towerUpgrade.ChangeLevel(towerLevel, towerCost);
            switch (towerLevel)
            {
                case 1:
                    tower.SetActive(true);
                    break;
                default:
                    tower.GetComponentInChildren<TowerAttack>().level = towerLevel;
                    break;
            }
           
        }
            
    }
    public void ArmyBtnClick()
    {
        if (Money.clsMoney.GetMoney() >= armyCost && armyLevel < 5)
        {
            Money.clsMoney.GainMoney(-armyCost);
            armyCost += 250;
            armyLevel++;

            ArmyUpgrade.armyUpgrade.ChangeLevel(armyLevel, armyCost);
        }
            
    }
    public void DigBtnClick()
    {
        if (Money.clsMoney.GetMoney() >=digCost && digLevel < 5)
        {
            Money.clsMoney.GainMoney(-digCost);
            digCost += 200;
            //digCostText.text = digCost.ToString();
            //digText.text = digLevel.ToString();
            digLevel++;
            CreeperUpg.creeperUpg.ChangeLevel(digLevel, digCost);

            Money.clsMoney.MoneyGainPerTimeChange(digLevel * 40);
        }
    }
}
