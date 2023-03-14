using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;
    [SerializeField] private UnitSpawnStats[] unitSpawnStats;
    [SerializeField] private Transform spawnPoint;
    private int[] spawnBuf = new int[] { -1, -1, -1, -1, -1 };
    private int curBufFlag = 0;

    private void Awake(){
        spawner = this;
    }

    public void Spawn() {
        Instantiate(unitSpawnStats[spawnBuf[0]].unit, spawnPoint);

        curBufFlag--;
        for (int i = 0; i < spawnBuf.Length - 1; i++)
            spawnBuf[i] = spawnBuf[i + 1];
        spawnBuf[spawnBuf.Length - 1] = -1;
        if(spawnBuf[0] == -1)
            SpawnCdUI.spawnCdUI.StartSpawning(spawnBuf, -1);
        else
            SpawnCdUI.spawnCdUI.StartSpawning(spawnBuf, unitSpawnStats[spawnBuf[0]].spawnCD);

    }
    
    private void AddToQueueUnit(int unitNumber){
        if (Money.clsMoney.GetMoney() >= unitSpawnStats[unitNumber].price && curBufFlag < 5){
            spawnBuf[curBufFlag] = unitNumber;
            curBufFlag++;
            Money.clsMoney.GainMoney(-unitSpawnStats[unitNumber].price);
            SpawnCdUI.spawnCdUI.StartSpawning(spawnBuf, unitSpawnStats[spawnBuf[0]].spawnCD);
        }
    }

    public static void getNuber(int unitNumber){
        spawner.AddToQueueUnit(unitNumber);
    }

    [System.Serializable]
    private struct UnitSpawnStats
    {
        public GameObject unit;
        public int price;
        public float spawnCD;
    }
}
