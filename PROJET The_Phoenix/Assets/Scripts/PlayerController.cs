using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D playerRB; // Propriété qui tiendra en réféence le rigid body de notre player
    SpriteRenderer playerRenderer; // Propriété qui tiendra la réféence du sprite rendered de notre
    Animator playerAnim; // Propriete qui tiendra la reference a notre composant animator
    public bool facingRight = true; // Par défaut, notre player regarde à droite
    public float maxSpeed; // Vitesse maximale que notre player peut atteindre en se déplacant
                           // Use this for initialization
    bool grounded = false; // Valeur qui traque si l'utilisateur est au sol ou non
    float groundCheckRadius = 0.2f; // Raduis du cercle pour tester si l'utilisateur est en contact avec le sol(Peut etre change en fonction des assets)
    public bool countJumps;
    public LayerMask groundLayer; // Rééence au layer avec lequel nous allons checker la colision
    public Transform groundCheck; // Rééence au GroundCheckLocation que nous avons déini dans le KnightPlayer
    public float jumpPower; // Force avec laquelle nous allons projeter notre personnage en l'air
    Transform weapons;

    Finish EndGame;
    public int nlife;
    public float targetTime = 3.0f;
    float timeDead = 2.0f;

    bool canMove = true; // Valeur qui traque si l'utilisateur peut bouger
    public bool canDoubleJumps = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>(); // On utilise GetComponent car notre Rb se
        playerRenderer = GetComponent<SpriteRenderer>();// Récupérer le component sprite renderer en dessous de cette ligne
        playerAnim = GetComponent<Animator>();
        weapons = this.gameObject.transform.GetChild(1);
        EndGame = FindObjectOfType<Finish>();
    }
    // Update is called once per frame
    void Update()
    {
        nlife = GetComponent<PlayerInventory>().life;
        if (nlife > 0)
        {
            //SHOOT**************************************************************
            bool shoot = Input.GetButtonDown("Fire1");
            //shoot |= Input.GetButtonDown("Fire2");
            // Astuce pour ceux sous Mac car Ctrl + flèches est utilisé par le système
            if (shoot)
            {
                WeaponScript weapon = GetComponent<WeaponScript>();
                if (weapon != null)
                {
                    // false : le joueur n'est pas un ennemi
                    weapon.Attack(false);
                }
            }
            //*******************************************************************
            //JUMPS**************************************************************

            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
            if (grounded == true)
                countJumps = true;
            if (grounded && (Input.GetKeyDown(KeyCode.UpArrow)))
            { // On verifie si l'utilisateur est au sol, et si l'input jump est en appui 
                playerAnim.SetBool("IsGrounded", false); // On defini le parametre danimation IsGrounded a faux car nous nous aprettons a sauter
                playerRB.velocity = new Vector2(playerRB.velocity.x, 0f); // On defini la velocite y a 0 pour etre sur d'avoir la même hauteur quelque soit le contexte
                playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse); // On ajoute de la force sur notre rigidbody afin de le faire s'envoler, on precise bien un forcement a impulse pour avoir toute la force d'un seul coup
                grounded = false; // On defini notre grounded a false pour garder en memoire l'etat du personnage
                countJumps = true;
            }

            if (canDoubleJumps)
            {
                if (countJumps == true && (Input.GetKeyDown(KeyCode.UpArrow)))
                {
                    playerRB.velocity = new Vector2(playerRB.velocity.x, 0f);
                    playerRB.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
                    countJumps = false;
                }
            }
            //*******************************************************************



            //print(countJumps);
            // on utilise ici notre moteur physique pour crér un petit cercle àn endroit bien precis(position du ground check personnage)
            // On defini aussi son radius pour dessiner le cercle
            // Et on defini le layer sur lequel on veut checker l'overlap
            // Si le cercle overlap avec le ground layer, ç va nous renvoyer vrai, car le player est au sol
            // Sinon cela veut dire que le personnage est en l'air
            // Cela va nous permetre aussi de declencer la condition permettant d'appliquer la force sur notre personnage


            //MOVEMENT*************************************************************
            playerAnim.SetBool("IsGrounded", grounded); // On utilise donc cette information pour mettre a jour note animator
            float move = Input.GetAxis("Horizontal");
            // Rédiger ci dessous le code permettant de déerminer quand le player doit se retourner
            if (canMove == true)
            {
                if (move < 0 && facingRight || move > 0 && !facingRight)
                    Flip();
                playerRB.velocity = new Vector2(move * maxSpeed, playerRB.velocity.y); // On utilise
                playerAnim.SetFloat("MoveSpeed", Mathf.Abs(move)); // Defini une valeur pour le float MoveSpeed dans notre animator
            }
            else
            {
                playerRB.velocity = new Vector2(0, playerRB.velocity.y); // Si movement non autorise, on arrete la velocite
                playerAnim.SetFloat("MoveSpeed", 0); // on arrete aussi l'animation en cours si on etait en train de courir
            }
            //***********************************************************************
            //SLEEP******************************************************************
            targetTime -= Time.deltaTime;
            //print("Temps: " + targetTime);
            if (Input.GetAxis("Horizontal") == 0 && !(Input.GetKeyDown(KeyCode.UpArrow)) && targetTime <= 0)
            {
                playerAnim.SetBool("Sleep", true);
            }
            if (Input.GetAxis("Horizontal") != 0 || (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                playerAnim.SetBool("Sleep", false);
                targetTime = 3;
            }
            //***********************************************************************
            if (facingRight)
            {
                weapons.transform.eulerAngles = new Vector2(0, 0);
                weapons.transform.localPosition = new Vector2(0.2f, -0.02f);
            }
            else
            {
                weapons.transform.eulerAngles = new Vector2(0, 180);
                weapons.transform.localPosition = new Vector2(-0.2f, -0.02f);
            }
        }
        else
            EndGame.MakeDead();
    }
    void Flip()
    {
        facingRight = !facingRight; // On change la valeur du boolen facing right par son contraire,
        playerRenderer.flipX = !playerRenderer.flipX; // Même chose ici pour que notre flipx et

    }
    public void toggleCanMove()
    {
        canMove = !canMove;
    }
}