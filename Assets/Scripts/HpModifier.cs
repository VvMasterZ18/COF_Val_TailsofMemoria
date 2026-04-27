using UnityEngine;

[RequireComponent(typeof(HealthManager))]
public class HpModifier : MonoBehaviour
{
    protected HealthManager _healthManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _healthManager = GetComponent<HealthManager>();
        _healthManager.AddModifier(this);
    }

    public virtual void OnHpChanged(int amount)
    {

    }

    public virtual void OnDie()
    {

    }

}
