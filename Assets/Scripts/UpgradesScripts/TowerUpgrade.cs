using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerUpgrade : MonoBehaviour
{
    public static TowerUpgrade towerUpgrade;
    //[SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject[] weaponsTable;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject skeleton;

    private int lvl = 1;
    private void Awake()
    {
        towerUpgrade = this;
    }
    public void ChangeLevel(int Level, int digCost)
    {
        if (Level == 1)
            skeleton.SetActive(true);
        //weapons[lvl - 1].SetActive(false);
        //weapons[Level - 1].SetActive(true);
        if (Level == 1)
            weaponsTable[lvl - 1].SetActive(false);
        else
            weaponsTable[lvl].SetActive(false);
        if (Level < 5)
            weaponsTable[Level].SetActive(true);

        if (Level == 5)
            text.text = "MAX";
        else
            text.text = digCost.ToString() + " =";
        lvl = Level;
    }
}
