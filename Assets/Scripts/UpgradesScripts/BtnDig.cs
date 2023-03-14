using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnDig : MonoBehaviour
{
    private void OnMouseDown()
    {
        UpgradesUI.upgradesUI.DigBtnClick();
    }
}
