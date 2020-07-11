using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_Ennemis : MonoBehaviour
{
    SpriteRenderer catRenderer;
    Animator CatAnim;                          //Variable of type Animator to store a reference to the enemy's Animator component.
    Transform target;                           //Transform to attempt to move toward each turn.
    //public Transform groundCheck;
    bool turn = false;
    bool grounded = false;
    bool facingRight = true;
    float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    public float targetTime = 0.2f;
    float time = 1f;
    bool comeAttack = false;
    int lvl;
    public bool setlife = false;
    public int rlife = 0;

    void Start()
    {
        // GameManager.instance.AddEnemyToList(this);
        CatAnim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Cat").transform;
        catRenderer = GetComponent<SpriteRenderer>();
        //base.Start();

    }
    void Update()
    {
        HitRight();
        HitLeft();
        targetTime -= Time.deltaTime;
        rlife = GameObject.Find("DifficultyMenu").GetComponent<Difficulties>().rlife;

        if (ViewDistance() <= 2 && ViewDistance() > 1)
        {
            facingRight = position();
            Flip();
            MoveR();

        }
        else
        {
            if (HitDown() == true)
            {
                //if (facingRight)
                MoveR();
                //else
                //MoveR();
            }
            if (HitDown() == false || (HitRight() == true || HitLeft() == true) && targetTime <= 0)
            {
                Flip();
                targetTime = 0.2f;
            }
            else if (targetTime <= 0)
                targetTime = 0.2f;
        }


        time -= Time.deltaTime;
        if (comeAttack == true && time < 0)
        {
            comeAttack = false;
            time = 1f;
        }
    }
    void MoveL()
    {
        transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        CatAnim.SetFloat("MoveSpeed", Mathf.Abs(1));
    }
    void MoveR()
    {
        transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
    }
    void Flip()
    {
        if (facingRight == true)
            transform.eulerAngles = new Vector2(0, 0);
        catRenderer.flipX = !catRenderer.flipX;
        if (facingRight == false)
            transform.eulerAngles = new Vector2(0, 180);
        catRenderer.flipX = !catRenderer.flipX;
        facingRight = !facingRight;
    }

    bool HitDown()
    {
        Transform groundCheckDown = gameObject.transform.GetChild(0);
        Vector2 position = groundCheckDown.position;
        Vector2 direction = Vector2.down;// + Vector2.left;
        float distance = 1.0f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.red);
        //Debug.Log(hit.collider);
        if (hit.collider == null)
            return false;
        else
            return true;
    }
    bool HitRight()
    {
        Transform groundCheckRight = gameObject.transform;
        Vector2 position = groundCheckRight.position;
        Vector2 direction = Vector2.right;// + Vector2.left;
        float distance = 0.7f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.red);
        //Debug.Log(hit.collider);
        if (hit.collider == null)
            return false;
        else
            return true;
    }
    bool HitLeft()
    {
        Transform groundCheckLeft = gameObject.transform;
        Vector2 position = groundCheckLeft.position;
        Vector2 direction = Vector2.left;// + Vector2.left;
        float distance = 0.7f;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        Debug.DrawRay(position, direction, Color.red);
        //Debug.Log(hit.collider);
        if (hit.collider == null)
            return false;
        else
            return true;
    }

    float ViewDistance()
    {
        Transform target;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        float view = Vector2.Distance(transform.position, target.transform.position);
        return view;
    }
    bool position()
    {
        Transform target;
        target = GameObject.FindGameObjectWithTag("Player").transform;
        if (gameObject.transform.position.x < target.transform.position.x)
            return true; // A sa gauche
        else
            return false; // A sa droite
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Player" && comeAttack == false) // Nous recuperons le tag de l'objet en colision
        {
            coll.gameObject.GetComponent<PlayerInventory>().RemoveLife(rlife);
            comeAttack = true;
        }
    }
}
