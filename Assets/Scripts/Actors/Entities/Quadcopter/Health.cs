using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Health:MonoBehaviour
{
    public event Action Died;

    private int _maxHP;

    private int _HP;
    
    public int HP
    {
        get { return _HP;}
        
        private set
        {
            _HP += value;

            if (_HP == 0)
            {
                Died?.Invoke();
            }
        }
    }
    
    private void Start()
    {
        ResetHP();
    }

    public void SetMaxHP(int maxHP)
    {
        _maxHP = maxHP;
    }
    public void Kill()
    {
        HP = 0;
        Debug.Log("Вы были убиты");
    }

    public void TakingDamage()
    {
        if (HP > 0)
        {
            HP -= 1;
            return;
        }
        
        Debug.Log("Ошибка, хп упало меньше 0");
    }

    public void ResetHP()
    {
        HP = _maxHP;
    }

    public void Healing()
    {
        if (HP < _maxHP)
            HP += 1;
    }
    
}
