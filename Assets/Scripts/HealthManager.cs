using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using static Unity.Cinemachine.CinemachineFreeLookModifier;

public class HealthManager : MonoBehaviour
{
    private int _hp;
    [SerializeField]
    private int _hpMax;
    
    [SerializeField]
    private List<DammageType> immunities;

    private List<HpModifier> _hpModifiers;

    public void AddModifier(HpModifier modifier)
    {
        if (_hpModifiers == null)
        {
            _hpModifiers = new List<HpModifier>();
        }

        _hpModifiers.Add(modifier);
    }

    public void ChangeHP(int newAmount)
    {
        _hp = newAmount;

        foreach (HpModifier modifier in _hpModifiers)
        {
            modifier.OnHpChanged(newAmount);
        }



        if (_hp <= 0)
        {
            Die();
        }
    }

    public void AddHp(int amount)
    {
        ChangeHP(_hp + amount);
    }

    public int GetHP()
    {
        return _hp;
    }

    public void Dammage(int amount, DammageType type)
    {
        if (immunities.Contains(type))
        {
            return;
        }
        else
        {
            AddHp(-amount);
        }
    }

    public void Die()
    {
        foreach (HpModifier modifier in _hpModifiers)
        {
            modifier.OnDie();
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChangeHP(_hpMax);

    }

}