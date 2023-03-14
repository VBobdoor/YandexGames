using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : MonoBehaviour
{
    [SerializeField] private float arrowRainCD;
    [SerializeField] private float arrowRainDuration;
    [SerializeField] private int damage;
    [SerializeField] private float speed;
    [SerializeField] private BoxAttack boxAttack;
    [SerializeField] private ParticleSystem particleSystem;
    private float currentArrowRainDuration = 0;
    private float currentArrowRainCD = 0;
    private bool isArrowRainReady = true;
    private bool isArrowRainHappend = false;

    private void Update()
    {
        if (isArrowRainHappend)
        {
            currentArrowRainCD += Time.deltaTime;
            if (currentArrowRainCD > arrowRainDuration)
            {
                StopArrowRain();
                currentArrowRainCD = 0;
            }
                
        }
        if (!isArrowRainReady)
        {
            currentArrowRainDuration += Time.deltaTime;
            if (currentArrowRainDuration > arrowRainCD)
            {
                isArrowRainReady = true;
                currentArrowRainDuration = 0;
            }
                
        }

    }

    public void StartArrowRain()
    {
        if (isArrowRainReady){
            isArrowRainReady = false;
            ArrowRain();
        }
            
    }
    private void ArrowRain()
    {
        isArrowRainHappend = true;
        particleSystem.Play();
        boxAttack.gameObject.SetActive(true);
        boxAttack.setStats(damage,speed);
    }
    private void StopArrowRain()
    {
        isArrowRainHappend = false;
        particleSystem.Stop();
        boxAttack.gameObject.SetActive(false);
    }
}
