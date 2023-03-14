using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadAppearUI : MonoBehaviour
{
    [SerializeField] private GameObject[] heades;
    private int head = - 1;

    public void ShowHead(int headNum)
    {
        if (head != -1)
            HideHead();
        head = headNum;
        heades[head].SetActive(true);
    }
    public void HideHead()
    {
        if (head == -1)
            return;
        heades[head].SetActive(false);
        head = -1;
    }
}
