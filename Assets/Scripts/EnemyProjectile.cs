using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * transform.localScale.x * 3;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.isTrigger & collision.gameObject.name != "Enemy")
        {
            if (collision.gameObject.name == "VvMaster")
            {
                Enemy enemy = collision.GetComponent<Enemy>();
                enemy.TakeDamage(transform.localScale.x * 10);
            }
            Object.Destroy(gameObject);
        }
    }
}
