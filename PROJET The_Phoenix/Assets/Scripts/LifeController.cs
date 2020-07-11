using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    Rigidbody2D playerRB;
    int rlife;

    void Update()
    {
        rlife = GameObject.Find("DifficultyMenu").GetComponent<Difficulties>().rlife;
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Ennemis")// Nous recuperons le tag de l'objet en colision
        {
            playerRB = GetComponent<Rigidbody2D>();
            GetComponent<PlayerInventory>().RemoveLife(rlife);
            playerRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            //playerRB.velocity *= -2;
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.tag == "Ennemis")// Nous recuperons le tag de l'objet en colision
        {
            playerRB = GetComponent<Rigidbody2D>();
            playerRB.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            //playerRB.velocity *= -2;
        }
    }
}
