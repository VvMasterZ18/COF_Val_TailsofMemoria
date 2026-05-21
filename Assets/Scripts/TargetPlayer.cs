using Unity.VisualScripting;
using UnityEngine;

public class TargetPlayer : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform cible;
    public bool distance;
    public GameObject attack;
    public float cd;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cible.GetComponent<Transform>().name = "VvMaster";
    }

    // Update is called once per frame
    void Update()
    {
        rb.rotation = Mathf.Atan2(cible.position.y - transform.position.y, cible.position.x - transform.position.x) * Mathf.Rad2Deg - 90;
        if (cd > 0)
        {
            cd -= Time.deltaTime;
        }
        else if (distance)
        {
            var Attack = Instantiate(attack, transform.position, transform.rotation);
            cd = 2;
        }
    }
}
