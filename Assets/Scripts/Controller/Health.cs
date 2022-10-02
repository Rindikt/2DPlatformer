using System;
using UnityEngine;

public sealed class Health
{
    public event Action ZeroHp;
    private float _maxHealth;
    private float _healthCurrent;
    
    public Health(float healthMax)
    {
        _maxHealth = healthMax;
        _healthCurrent = healthMax;
    }

    public void GetDamage(float demage)
    {
        _healthCurrent -= demage;
        Debug.Log(_healthCurrent);
        if (_healthCurrent<=0)
        {
            ZeroHp?.Invoke();
            _healthCurrent = _maxHealth;
        }
    }

    public void Heal(float heal)
    {
        _healthCurrent += heal;
        if (_healthCurrent>_maxHealth)
        {
            _healthCurrent = _maxHealth;
        }
    }
}