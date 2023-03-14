using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    private struct Waves
    {
        public int[] unit;
        public float[] delayBetweenMobs;
        public float waveTime;
    }

    [SerializeField] private Waves[] waves;
    public static EnemySpawner enemySpawner;
    [SerializeField] private GameObject[] units;
    [SerializeField] private int[] unitsDrop;
    [SerializeField] private Transform spawnPoint;
    private bool isAutoSpawnWork = false;
    private bool isTimerWork = false;
    private float currentTime = 0;
    private int waveNumber = 0;

    private void Awake()
    {
        enemySpawner = this;
    }

    private void Update()
    {

        if (isAutoSpawnWork == true && isTimerWork == false)
        {
            currentTime += Time.deltaTime;
            if (currentTime > waves[waveNumber].waveTime)
            {
                if (waveNumber < waves.Length - 1){
                    waveNumber++;  
                }
                currentTime = 0;
            }

            StartCoroutine(timer(Random.Range(waves[waveNumber].delayBetweenMobs[0],waves[waveNumber].delayBetweenMobs[1])));


        }


    }

    public void startWaves(){
        isAutoSpawnWork = true;
    }

    private IEnumerator timer(float time)
    {
        isTimerWork = true;
         yield return new WaitForSeconds(time);
        SummonPirate(waves[waveNumber].unit[Random.Range(0, waves[waveNumber].unit.Length)]);
        isTimerWork = false;

    }

    public void SummonPirate(int unitNumber)
    {
        GameObject unit = Instantiate(units[unitNumber], spawnPoint);
        unit.GetComponent<UnitMovement>().ChangeDirection(false);
        unit.GetComponent<Health>().dropMoney = unitsDrop[1];
    }
    public void SummonZomb()
    {
        GameObject unit = Instantiate(units[0], spawnPoint);
        unit.GetComponent<UnitMovement>().ChangeDirection(false);
        unit.GetComponent<Health>().dropMoney = unitsDrop[0];



    }
    public void SummonSkel()
    {
        GameObject unit = Instantiate(units[2], spawnPoint);
        unit.GetComponent<UnitMovement>().ChangeDirection(false);
        unit.GetComponent<Health>().dropMoney = unitsDrop[2];
    }
    public void SummonSpid()
    {
        GameObject unit = Instantiate(units[1], spawnPoint);
        unit.GetComponent<UnitMovement>().ChangeDirection(false);
        unit.GetComponent<Health>().dropMoney = unitsDrop[1];
    }
    public void SummonEnd()
    {
        GameObject unit = Instantiate(units[3], spawnPoint);
        unit.GetComponent<UnitMovement>().ChangeDirection(false);
        unit.GetComponent<Health>().dropMoney = unitsDrop[3];
    }
    public void SummonRav()
    {
        GameObject unit = Instantiate(units[4], spawnPoint);
        unit.GetComponent<UnitMovement>().ChangeDirection(false);
        unit.GetComponent<Health>().dropMoney = unitsDrop[4];
    }



}
