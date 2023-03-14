using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ArmyUpgrade : MonoBehaviour
{
    public static ArmyUpgrade armyUpgrade;
    [SerializeField] private GameObject[] units;
    [SerializeField] private GameObject[] unitsTable;
    [SerializeField] private GameObject[] unitsUI;

    [SerializeField] private TextMeshPro text;

    private int lvl = 1;
    private void Awake()
    {
        armyUpgrade = this;
    }
    public void ChangeLevel(int Level, int digCost)
    {
        units[Level - 1].SetActive(true);
        unitsUI[Level - 1].SetActive(true);
        if (Level == 1)
            unitsTable[lvl - 1].SetActive(false);
        else
            unitsTable[lvl].SetActive(false);
        if (Level < 5)
            unitsTable[Level].SetActive(true);

        if (Level == 5)
            text.text = "MAX";
        else
            text.text = digCost.ToString() + " =";
        lvl = Level;
    }
}
