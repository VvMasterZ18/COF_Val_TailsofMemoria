using System.Collections.Generic;
using UnityEngine;

public class ListSkill : MonoBehaviour
{

    public List<bool> skill;
    public List<float> cooldown;
    public PlayerAttack attack;
    public GameObject projectile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)& cooldown[0] <= 0 & skill[1])
        {
            attack.Attack(20, 1.75f);
            cooldown[0] = 10;
        }
        for (int i = 0; i < cooldown.Count; i++)
        {
            if (cooldown[i] > 0)
            {
                cooldown[i] -= Time.deltaTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.Keypad1) & cooldown[1] <= 0 & skill[2])
        {
            var proj = Instantiate(projectile, transform.position, transform.rotation);
            cooldown[1] = 7;
        }

        if (Input.GetKeyDown(KeyCode.Keypad2) & cooldown[2] <= 0 & skill[3])
        {
            attack.Attack(30, 5);
            cooldown[2] = 15;
        }
        if (Input.GetKeyDown(KeyCode.Keypad3) & cooldown[3] <= 0 & skill[4])
        {
            var proj = Instantiate(projectile, transform.position, transform.rotation);
            cooldown[3] = 12;
            proj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }

    }
}
