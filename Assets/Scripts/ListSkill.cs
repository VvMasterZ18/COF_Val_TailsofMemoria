using System.Collections.Generic;
using UnityEngine;

public class ListSkill : MonoBehaviour
{

    public List<bool> skill;
    public List<float> cooldown;
    public PlayerAttack attack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)& cooldown[0] <= 0 & skill[1])
        {
            attack.Attack(20, 1);
            cooldown[0] = 10;
        }
        for (int i = 0; i < cooldown.Count; i++)
        {
            if (cooldown[i] > 0)
            {
                cooldown[i] -= Time.deltaTime;
            }
        }
    }
}
