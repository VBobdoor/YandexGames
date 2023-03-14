using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CreeperUpg : MonoBehaviour
{
    public static CreeperUpg creeperUpg;
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject[] weaponsTable;
    [SerializeField] private TextMeshPro text;
    [SerializeField] private GameObject miner;

    private int lvl = 1;
    private void Awake()
    {
        creeperUpg = this;
    }
    public void ChangeLevel(int Level, int digCost)
    {
        weapons[lvl - 1].SetActive(false);
        weapons[Level - 1].SetActive(true);
        if(Level == 1)
        {
            miner.SetActive(true);
            weaponsTable[lvl - 1].SetActive(false);
        }    
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
