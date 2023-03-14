using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour {
    public int dropMoney;
    [Header("Health stats")]
    [SerializeField] private GameObject hpBar;
    [SerializeField] private GameObject parent;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private HealthBar healthBar;
    private int _currentHealth;
    
    void Start() {
        _currentHealth = _maxHealth;
    }
                                
    public void ChangeHealth(int value)    
   {
        hpBar.SetActive(true);
         _currentHealth += value;
        if(_currentHealth <= 0)
        {
            Money.clsMoney.GainMoney(dropMoney);
            Death();
        }
        else
        {
            float _currentHealtAsPercantage = (float)_currentHealth / _maxHealth;
            healthBar.OnHealthChanged(_currentHealtAsPercantage);
        }
   }
    private void Death()
    {
        Destroy(parent);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            ChangeHealth(-10);
        }
    }
}
