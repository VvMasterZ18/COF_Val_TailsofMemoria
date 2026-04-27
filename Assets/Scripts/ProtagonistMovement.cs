using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

public class ProtagonistMovement : MonoBehaviour
{
    public Rigidbody2D rb; //Ne pas oublier d'activer la gravity scale du rigidbody et d'ajouter un collider
    public float speed = 1;
    public float dashSpeed = 5;
    public float jumpforce = 1;
    public float superjumpforce = 5;
    public LayerMask mask; //Quels layer seront affecté par le raycast attention a ne pas ajouter le layer de votre perso sinon le raycast va trouver le perso avant de trouver le sol
    public bool isGrounded;
    public bool isDashing;
    public void Update()
    {
        var hDirection = 0f;
        var vDirection = 0f;
        isGrounded = CheckGround();
        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vDirection += jumpforce;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            hDirection += -1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            hDirection += 1;
        }

        if(!isDashing)
        {
            rb.linearVelocity = new Vector2(hDirection * speed, rb.linearVelocityY + vDirection); //On set up la velocité horizontal 
        }
    }

    public void Dash()
    {
        rb.AddForceX(rb.linearVelocity.x*dashSpeed);
        StartCoroutine(DashRoutine());
    }

    private IEnumerator DashRoutine()
    {
        isDashing = true;
        yield return new WaitForSeconds(0.5f);
        isDashing = false;
    }


    public bool CheckGround()
    {
        var rayCastHit = Physics2D.Raycast(transform.position, new Vector2(0, -1), 1.1f, mask);
        if (rayCastHit)
        {
            return true;
        }
        return false;
    }
}
