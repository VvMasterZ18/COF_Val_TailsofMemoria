using NUnit.Framework;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform playerTransform;
    public float moveSpeed;
    public bool isChasing;
    public float chaseDistance;
    public DetectPlayer dp;
    public Enemy enemy;

    // Update is called once per frame
    void Update()
    {
        if (enemy.diff != 1)
        {
            if (isChasing)
            {
                if (transform.position.x > playerTransform.position.x)
                {
                    transform.localScale = new Vector3(3.85f, 4, 1);
                    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                }
                if (transform.position.x < playerTransform.position.x)
                {
                    transform.localScale = new Vector3(-3.85f, 4, 1);
                    transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                }
            }

            else
            {
                if (Vector2.Distance(transform.position, playerTransform.position) < chaseDistance)
                {
                    isChasing = true;
                }
            }
        }
        else if (dp.player != null) 
        {
            var distance = Mathf.Sqrt(((transform.position.x - dp.player.transform.position.x)
                             * (transform.position.x - dp.player.transform.position.x))
                             - ((transform.position.y - dp.player.transform.position.y)
                             * (transform.position.y - dp.player.transform.position.y)));
            if (distance >5)
            {
                transform.position += new Vector3((transform.position.x - dp.player.transform.position.x), (transform.position.y - dp.player.transform.position.y), 0) * Time.deltaTime * moveSpeed;
            }
            else if(distance < 2)
            {
                transform.position += new Vector3((transform.position.x - dp.player.transform.position.x), (transform.position.y - dp.player.transform.position.y), 0) * Time.deltaTime * -moveSpeed;
            }
            else
            {

            }
        }
    }
}
