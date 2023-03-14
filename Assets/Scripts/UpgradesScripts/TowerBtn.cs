using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBtn : MonoBehaviour
{
    private void OnMouseDown()
    {
        UpgradesUI.upgradesUI.TowerBtnClick();
    }
}

