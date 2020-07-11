using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Worms : MonoBehaviour
{
    SpriteRenderer wormsRenderer;
    Animator WormsAnim;                          //Variable of type Animator to store a reference to the enemy's Animator component.
    Transform target;                           //Transform to attempt to move toward each turn.
    public Transform groundCheck;
    bool grounded = false;
    bool facingRight = true;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;

    void Start()
    {
        // GameManager.instance.AddEnemyToList(this);
        WormsAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Worms").transform;
        wormsRenderer = GetComponent<SpriteRenderer>();
        //base.Start();
    }
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (grounded == true)
        {
            WormsAnim.SetBool("IsGrounded", true);
            //if (facingRight)
                MoveL();
            //else
                //MoveR();
        }
        if (grounded == false)
        {
            Flip();
            WormsAnim.SetBool("IsGrounded", true);
        }
    }
    void MoveL()
    {
        transform.Translate(Vector3.left * Time.deltaTime/2);//Vector2.left * Time.deltaTime
        WormsAnim.SetFloat("MoveSpeed", Mathf.Abs(1));
    }
    void MoveR()
    {
        transform.Translate(Vector2.right * Time.deltaTime/2);
        WormsAnim.SetFloat("MoveSpeed", Mathf.Abs(1));
    }
    void Flip()
    {
        if(facingRight==true)
            transform.eulerAngles = new Vector2(0, 0);
            wormsRenderer.flipX = !wormsRenderer.flipX;
        if (facingRight==false)
            transform.eulerAngles = new Vector2(0, 180);
            wormsRenderer.flipX = !wormsRenderer.flipX;
        facingRight = !facingRight;
    }
    bool Hit()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down + Vector2.left;
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
    }
}