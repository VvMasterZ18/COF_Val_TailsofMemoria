using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public Transform attackPoint;
    public LayerMask enemyLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack(attackDamage, attackRange);
        }
        
    }

    public void Attack(int damage, float range)
    {
        Collider2D[] hitEnnemies = Physics2D.OverlapCircleAll(attackPoint.position, range, enemyLayer);

        foreach(Collider2D enemy in hitEnnemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
